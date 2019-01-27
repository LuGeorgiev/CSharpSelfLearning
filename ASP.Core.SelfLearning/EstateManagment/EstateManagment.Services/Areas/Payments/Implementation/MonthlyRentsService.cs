using AutoMapper;
using EstateManagment.Data;
using EstateManagment.Data.Models;
using EstateManagment.Data.Models.Enums;
using EstateManagment.Services.Implementation;
using EstateManagment.Services.Models.Areas.Payments.MonthlyRents;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstateManagment.Services.Areas.Payments.Implementation
{
    public class MonthlyRentsService : BaseService, IMonthlyRentsService
    {
        public MonthlyRentsService(IMapper mapper, EstateManagmentContext db)
            : base(mapper, db)
        {
        }

        public async Task<IEnumerable<MonthlyRentListingModel>> AllNotPaidAsync(bool isPaid = false)
        {
            var notPaid = await this.Db.MonthlyPaymentRents
                .Where(x => x.IsPaid == isPaid)
                .OrderBy(x => x.DeadLine)
                .ToListAsync();

            var notPaidModel = this.Mapper.Map<IEnumerable<MonthlyRentListingModel>>(notPaid);
            return notPaidModel;
        }

        public async Task<bool> CreateAsync(int idRentAgreement, decimal totalPayment, DateTime deadLine)
        {
            var rentAgreement = await this.Db.FindAsync<RentAgreement>(idRentAgreement);
            if (rentAgreement==null)
            {
                return false;
            }
            //applying VAT
            totalPayment *= 1.20m;            

            rentAgreement.MonthlyRents.Add(new MonthlyPaymentRent()
            {
                DeadLine=deadLine,
                ApplyVAT=true,
                TotalPayment = totalPayment                 
            });

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

        public async Task<bool> CreateNextMonthPayment(int monthlyRentId)
        {
            var monthlyRent = await this.Db
                .FindAsync<MonthlyPaymentRent>(monthlyRentId);
            if (monthlyRent==null)
            {
                return false;
            }

            this.Db.MonthlyPaymentRents.Add(new MonthlyPaymentRent()
            {
                ApplyVAT = monthlyRent.ApplyVAT,
                DeadLine = monthlyRent.DeadLine.AddMonths(1),
                RentAgreementId = monthlyRent.RentAgreementId,
                TotalPayment = (monthlyRent.RentAgreement.MonthlyPrice+monthlyRent.RentAgreement.ParkingSlots.Sum(x=>x.Price*x.Quantity)) * 1.2m
            });
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

        public async Task<bool> EditAsync(MonthlyRentViewModel model)
        {
            var monthlyRent = await this.Db
                .FindAsync<MonthlyPaymentRent>(model.Id);
            if (monthlyRent==null 
                || monthlyRent.IsPaid==true
                || model.TotalPayment-monthlyRent.Payments.Sum(x=>x.Amount)<0)
            {
                return false;
            }
            monthlyRent.DeadLine = model.DeadLine;
            monthlyRent.TotalPayment = model.TotalPayment;
            this.Db.MonthlyPaymentRents.Update(monthlyRent);

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

        public async Task<MonthlyRentViewModel> GetByIdAsync(int id)
        {
            var monthlyRent = await this.Db.FindAsync<MonthlyPaymentRent>(id);
            if (monthlyRent==null)
            {
                return null;
            }
            return Mapper.Map<MonthlyRentViewModel>(monthlyRent);
        }

        public async Task<CreateMonthlyRentFormViewModel> GetDetailsAsync(int rentAgreementId)
        {
            var rentAgreement = await this.Db
                .FindAsync<RentAgreement>(rentAgreementId);
            if (rentAgreement==null)
            {
                return null;
            }
            var result = Mapper.Map<CreateMonthlyRentFormViewModel>(rentAgreement);

            return result;
        }

        public async Task<bool> TerminateAsync(int id)
        {
            var monthlyRent = await this.Db
               .FindAsync<MonthlyPaymentRent>(id);

            if (monthlyRent == null || monthlyRent.IsPaid == true)
            {
                return false;
            }
            this.Db.MonthlyPaymentRents.Remove(monthlyRent);

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

        public async Task<IEnumerable<OverdueMontlyRentsListingModel>> AllOverdueRentsAsync()
        {
            var overdueRents = await this.Db.MonthlyPaymentRents
                .Where(x => x.IsPaid == false && x.DeadLine < DateTime.UtcNow)
                .OrderBy(x=>x.DeadLine)
                .ToListAsync();
            var model = this.Mapper.Map<IEnumerable<OverdueMontlyRentsListingModel>>(overdueRents);
            return model;
        }

        public async Task<InvoiceBindingModel> SentNumberAsync(InvoiceBindingModel model)
        {
            var monthlyRent = await this.Db.FindAsync<MonthlyPaymentRent>(model.Id);
            if (monthlyRent ==null)
            {
                return null;
            }
            monthlyRent.InvoiceNumber = model.InvoiceNumber;
            this.Db.Update(monthlyRent);
            try
            {
                await this.Db.SaveChangesAsync();
            }
            catch (Exception )
            {
                return null;
            }

            return model;
        }

        public async Task<FilteredParkingInfo> ParkingStatisticAsync(DateTime fromDate, DateTime toDate, int ClientId = 0, int parkingType = 0)
        {
            var filterDetails = $"Аргументите на филтъра са: от {fromDate.ToString("dd/MM/yyyy")} до {toDate.ToString("dd/MM/yyyy")}, ";
            var monthlyRents = await this.Db.MonthlyPaymentRents
                .Where(x => x.IsPaid == true && x.DeadLine >= fromDate && x.DeadLine <= toDate)
                .ToListAsync();
            // filter if client was given
            if (ClientId!=0)
            {
                monthlyRents = monthlyRents
                    .Where(x => x.RentAgreement.ClientId == ClientId)
                    .ToList();

                var client = await this.Db.Clients.FirstOrDefaultAsync(x=>x.Id==ClientId);
                if (client==null)
                {
                    return null;
                }
                else
                {
                    filterDetails += $"за клиент {client.Name}, ";

                }
            }
            else
            {
                filterDetails += "за всички клиенти, ";
            }

            // filter if parking type is given
            var parkingStat = new SortedDictionary<string, ParkingRentMonthView>();
            if (parkingType != 0)
            {
                foreach (var rent in monthlyRents)
                {
                    if (!rent.RentAgreement.ParkingSlots.Any(x=>x.Type==(ParkingSlotType)parkingType))
                    {
                        continue;
                    }
                    var month = rent.DeadLine.Month.ToString();
                    var year = rent.DeadLine.Year.ToString();
                    var key = year + month;
                    var isInCash = false;

                    if (rent.Payments.Any(x=>x.CashPayment==true))
                    {
                        isInCash = true;
                    }

                    if (!parkingStat.ContainsKey(key))
                    {
                        parkingStat.Add(key, new ParkingRentMonthView());
                    }

                    //Populate parking by Single types with corresponding sums
                    foreach (var parkingSolt in rent.RentAgreement.ParkingSlots)
                    {
                        if (parkingSolt.Type == (ParkingSlotType)parkingType)
                        {
                            parkingStat[key].BigTrucksQty += parkingSolt.Quantity;
                            parkingStat[key].BigTrucksTotal += parkingSolt.Quantity * parkingSolt.Price*1.2m;
                            if (isInCash)
                            {
                                parkingStat[key].CashTotal += parkingSolt.Quantity * parkingSolt.Price*1.2m;
                            }
                        }                        
                    }
                }
                if (parkingType == 1)
                {
                    filterDetails += "само за коли!";
                }
                else if (parkingType == 2)
                {
                    filterDetails += "само за рейсове!";
                }
                else if (parkingType == 3)
                {
                    filterDetails += "само за камиони!";
                }
                else if (parkingType == 4)
                {
                    filterDetails += "само за големи камиони!";
                }
                else if (parkingType == 5)
                {
                    filterDetails += "само за автомобилни клетки!";
                }
                else if (parkingType == 6)
                {
                    filterDetails += "само други!";
                }
            }
            else
            {
                foreach (var rent in monthlyRents)
                {
                    var month = rent.DeadLine.Month.ToString();
                    var year = rent.DeadLine.Year.ToString();
                    var key = year + month;
                    var isInCash = false;

                    if (rent.Payments.Any(x => x.CashPayment == true))
                    {
                        isInCash = true;
                    }
                    if (!parkingStat.ContainsKey(key))
                    {
                        parkingStat.Add(key, new ParkingRentMonthView());
                    }
                                       

                    //Populate parking by types with corresponding sums
                    foreach (var parkingSolt in rent.RentAgreement.ParkingSlots)
                    {
                        if (parkingSolt.Type == ParkingSlotType.BigTruck)
                        {
                            parkingStat[key].BigTrucksQty += parkingSolt.Quantity;
                            parkingStat[key].BigTrucksTotal += parkingSolt.Quantity * parkingSolt.Price*1.2m;
                            if (isInCash)
                            {
                                parkingStat[key].CashTotal+= parkingSolt.Quantity * parkingSolt.Price * 1.2m;
                            }
                        }
                        else if (parkingSolt.Type == ParkingSlotType.Bus)
                        {
                            parkingStat[key].BusesQty += parkingSolt.Quantity;
                            parkingStat[key].BusesTotal += parkingSolt.Quantity * parkingSolt.Price * 1.2m;
                            if (isInCash)
                            {
                                parkingStat[key].CashTotal += parkingSolt.Quantity * parkingSolt.Price * 1.2m;
                            }
                        }
                        else if (parkingSolt.Type == ParkingSlotType.Car)
                        {
                            parkingStat[key].CarsQty += parkingSolt.Quantity;
                            parkingStat[key].CarsTotal += parkingSolt.Quantity * parkingSolt.Price * 1.2m;
                            if (isInCash)
                            {
                                parkingStat[key].CashTotal += parkingSolt.Quantity * parkingSolt.Price * 1.2m;
                            }
                        }
                        else if (parkingSolt.Type == ParkingSlotType.CarCage)
                        {
                            parkingStat[key].CarCagesQty += parkingSolt.Quantity;
                            parkingStat[key].CarCagesTotal += parkingSolt.Quantity * parkingSolt.Price * 1.2m;
                            if (isInCash)
                            {
                                parkingStat[key].CashTotal += parkingSolt.Quantity * parkingSolt.Price * 1.2m;
                            }
                        }
                        else if (parkingSolt.Type == ParkingSlotType.Other)
                        {
                            parkingStat[key].OthersQty += parkingSolt.Quantity;
                            parkingStat[key].OthersTotal += parkingSolt.Quantity * parkingSolt.Price * 1.2m;
                            if (isInCash)
                            {
                                parkingStat[key].CashTotal += parkingSolt.Quantity * parkingSolt.Price * 1.2m;
                            }
                        }
                        else if (parkingSolt.Type == ParkingSlotType.Truck)
                        {
                            parkingStat[key].TrucksQty += parkingSolt.Quantity;
                            parkingStat[key].TrucksTotal += parkingSolt.Quantity * parkingSolt.Price * 1.2m;
                            if (isInCash)
                            {
                                parkingStat[key].CashTotal += parkingSolt.Quantity * parkingSolt.Price * 1.2m;
                            }
                        }
                    }
                }
                filterDetails += "за всички видове паркоместа!";
            }


            var result = new FilteredParkingInfo()
            {
                FilterDetails =filterDetails,
                InfoByMonths = parkingStat
            };
            
            return result;
        }
    }
}
