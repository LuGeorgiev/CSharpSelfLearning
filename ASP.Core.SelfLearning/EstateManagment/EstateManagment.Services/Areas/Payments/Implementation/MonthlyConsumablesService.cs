﻿using AutoMapper;
using EstateManagment.Data;
using EstateManagment.Data.Models;
using EstateManagment.Services.Areas.Payments.Models.MonthlyConsumables;
using EstateManagment.Services.Implementation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstateManagment.Services.Areas.Payments.Implementation
{
    public class MonthlyConsumablesService : BaseService, IMonthlyConsumablesService
    {
        public MonthlyConsumablesService(IMapper mapper, EstateManagmentContext db) 
            : base(mapper, db)
        {
        }

        public async Task<IEnumerable<MonthlyConsumablesListingModel>> AllNotPaid()
        {
            var allUnpaidConsumables = await this.Db.MonthlyPaymentConsumables
                .Where(x => x.PaymentId == null)
                .OrderByDescending(x=>x.DeadLine)
                .ToListAsync();
            var listingConsumables = Mapper.Map<IEnumerable<MonthlyConsumablesListingModel>>(allUnpaidConsumables);

            return listingConsumables;
        }

        public async Task<bool> CreateMonthlyConsumable(MonthlyConsumablesBindingModel model)
        {
            var rentAgreement = await this.Db
                .FindAsync<RentAgreement>(model.rentId);
            if (rentAgreement == null)
            {
                return false;
            }

            var monthlyConsumables = Mapper.Map<MonthlyPaymentConsumable>(model);
            rentAgreement.MonthlyConsumables
                .Add(monthlyConsumables);
            try
            {
                await this.Db.SaveChangesAsync();
            }
            catch (System.Exception)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> EditAsync(EditMontlyConsumablesModel model)
        {
            var consumables = await this.Db.FindAsync<MonthlyPaymentConsumable>(model.Id);
            if (consumables==null)
            {
                return false;
            }
            consumables.DeadLine = model.DeadLine;
            consumables.ElectricityDay = model.ElectricityDay;
            consumables.ElectricityNight = model.ElectricityNight;
            consumables.ElectricityPeak = model.ElectricityPeak;
            consumables.PaymentForElectricity = model.PaymentForElectricity;
            consumables.PaymentForWater = model.PaymentForWater;
            consumables.WaterReport = model.WaterReport;

            this.Db.MonthlyPaymentConsumables.Update(consumables);

            try
            {
                await this.Db.SaveChangesAsync();
            }
            catch (System.Exception)
            {
                return false;
            }
            return true;
        }

        public async Task<MonthlyConsumablesViewModel> GetByIdAsync(int id)
        {
            var consumables = await this.Db.FindAsync<MonthlyPaymentConsumable>(id);
            if (consumables==null)
            {
                return null;
            }
            var model = Mapper.Map<MonthlyConsumablesViewModel>(consumables);
            return model;
        }

        public async Task<CreateMonthlyConsumablesModel> GetCreateInfoAsync(int rentId)
        {
            var rentAgreement = await this.Db.FindAsync<RentAgreement>(rentId);
            if (rentAgreement==null)
            {
                return null;
            }
            var result = Mapper.Map<CreateMonthlyConsumablesModel>(rentAgreement);

            return result;
        }

        public async Task<bool> TerminateAsync(int id)
        {
            var consumables = await this.Db.FindAsync<MonthlyPaymentConsumable>(id);
            if (consumables == null)
            {
                return false;
            }
            this.Db.MonthlyPaymentConsumables.Remove(consumables);
            try
            {
                await this.Db.SaveChangesAsync();
            }
            catch (System.Exception)
            {
                return false;
            }

            return true;
        }

        public async Task<IEnumerable<OverdueMonthlyConsumablesListingModel>> AllOverduConsumablesAsync()
        {
            var overduConsumables = await this.Db.MonthlyPaymentConsumables
                .Where(x => x.PaymentId == null && x.DeadLine < DateTime.UtcNow)
                .ToListAsync();

            var model = Mapper.Map<IEnumerable<OverdueMonthlyConsumablesListingModel>>(overduConsumables);
            return model;
        }
    }
}
