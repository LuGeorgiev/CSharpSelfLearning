﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EstateManagment.Data;
using EstateManagment.Data.Models;
using EstateManagment.Data.Models.Enums;
using EstateManagment.Services.Areas.Payments;
using EstateManagment.Services.Models.Rents;
using Microsoft.EntityFrameworkCore;

namespace EstateManagment.Services.Implementation
{
    public class RentsService : BaseService, IRentsService
    {
        private readonly IMonthlyRentsService monthlyRents;

        public RentsService(IMapper mapper, EstateManagmentContext db, IMonthlyRentsService monthlyRents) 
            : base(mapper, db)
        {
            this.monthlyRents = monthlyRents;
        }

        public async Task<IEnumerable<RentListingViewModel>> AllAsync(bool isActual=true)
        {
            var rentAgreements = await this.Db.RentAgreements
                .Where(x => x.IsActual == isActual)
                .OrderBy(x=>x.Client.Name)
                .ToListAsync();
            var model = Mapper.Map<IEnumerable<RentListingViewModel>>(rentAgreements);

            return model;
        }

        public async Task<bool?> CreateAsync(CreateRentModel model)
        {
            var rentAgreement = new RentAgreement()
            {
                StartDate=model.StartDate,
                EndDate=model.EndDate,
                ClientId=model.ClientId,
                Description=model.Description,
                ParkingSlotDescription=model.ParkingSlotDescription,
                MonthlyPrice=model.MonthlyPrice
            };

            if (model.PropertiesIds!=null)
            {
                var listProperties = new List<PropertyRent>();
                foreach (var propertyId in model.PropertiesIds)
                {
                    listProperties.Add(new PropertyRent() { PropertyId = propertyId });
                }
                rentAgreement.PropertyRents = listProperties;
            }

            var listParkingSlots = new List<ParkingSlot>();
            if (model.CarSlots>0)
            {
                listParkingSlots.Add(new ParkingSlot()
                {
                     Type=ParkingSlotType.Car,
                     Quantity=model.CarSlots,
                     Price=model.CarMonthPrice,
                     Area=model.CarsArea
                });
            }
            if (model.BusSlots > 0)
            {
                listParkingSlots.Add(new ParkingSlot()
                {
                    Type = ParkingSlotType.Bus,
                    Quantity = model.BusSlots,
                    Price = model.BusMonthPrice,
                    Area=model.BusesArea
                });
            }
            if (model.TruckSlots > 0)
            {
                listParkingSlots.Add(new ParkingSlot()
                {
                    Type = ParkingSlotType.Truck,
                    Quantity = model.TruckSlots,
                    Price = model.TruckMonthPrice,
                    Area = model.TrucksArea
                });
            }
            if (model.BigTruckSlots > 0)
            {
                listParkingSlots.Add(new ParkingSlot()
                {
                    Type = ParkingSlotType.BigTruck,
                    Quantity = model.BigTruckSlots,
                    Price = model.BigTruckMonthPrice,
                    Area = model.BigTrucksArea
                });
            }
            if (model.CarCageSlots > 0)
            {
                listParkingSlots.Add(new ParkingSlot()
                {
                    Type = ParkingSlotType.CarCage,
                    Quantity = model.CarCageSlots,
                    Price = model.CarCageMonthPrice,
                    Area =model.CarCagesArea
                });
            }
            if (model.OtherSlots > 0)
            {
                listParkingSlots.Add(new ParkingSlot()
                {
                    Type = ParkingSlotType.Other,
                    Quantity = model.OtherSlots,
                    Price = model.OtherMonthPrice,
                    Area = model.OthersArea
                });
            }
            rentAgreement.ParkingSlots = listParkingSlots;

            var result = await this.Db.RentAgreements.AddAsync(rentAgreement);
            try
            {
                await this.Db.SaveChangesAsync();
            }
            catch (Exception)
            {
                return false;
            }
            int deadlineYear = DateTime.UtcNow.Year;
            int deadlineMonth = DateTime.UtcNow.Month;
            var deadline = new DateTime(deadlineYear, deadlineMonth, 5);

            var totalPrice = result.Entity.MonthlyPrice + result.Entity.ParkingSlots.Sum(x => x.Price * x.Quantity);
            var isPaymentCreated = await this.monthlyRents.CreateAsync(result.Entity.Id, totalPrice, deadline);

            if (!isPaymentCreated)
            {
                return null;
            }

            return true;
        }

        public async Task<bool> EditDescriptionsAsync(string description, string parkingSlotDescription, int id)
        {
            var rentAgreement = await this.Db.RentAgreements
                .FirstOrDefaultAsync(x => x.Id == id);
            if (rentAgreement==null)
            {
                return false;
            }

            rentAgreement.Description = description;
            rentAgreement.ParkingSlotDescription = parkingSlotDescription;
            this.Db.RentAgreements.Update(rentAgreement);
            try
            {
                await this.Db.SaveChangesAsync();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public async Task<RentDetailsModel> GetDetailsAsync(int id)
        {
            var rentAgreement = await this.Db.RentAgreements
                .FirstOrDefaultAsync(x => x.Id==id);
            if (rentAgreement==null)
            {
                return null;
            }

            var result = Mapper.Map<RentDetailsModel>(rentAgreement);
            return result;
        }

        public async Task<bool> TerminateAsync(int id)
        {
            var rentAgreement = await this.Db.RentAgreements
                .FirstOrDefaultAsync(x => x.Id == id);

            if (rentAgreement==null)
            {
                return false;
            }
            if (rentAgreement.IsActual)
            {
                rentAgreement.IsActual = false;
                rentAgreement.EndDate = DateTime.UtcNow;
            }
            else
            {
                rentAgreement.IsActual = true;
            }

            this.Db.RentAgreements.Update(rentAgreement);
            try
            {
                await this.Db.SaveChangesAsync();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> UploadContractAsync(byte[] fileContent, int id)
        {
            var rentAgreement = await this.Db.RentAgreements
                .FirstOrDefaultAsync(x => x.Id == id);
            if (rentAgreement==null)
            {
                return false;
            }

            rentAgreement.Contracts.Add(new Contract { ScannedContract=fileContent });
            try
            {
                await this.Db.SaveChangesAsync();
            }
            catch (Exception)
            {
                return false;                
            }

            return true;
        }
    }
}
