using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EstateManagment.Data;
using EstateManagment.Data.Models;
using EstateManagment.Services.Areas.Payments.Models.MonthlyRents;
using EstateManagment.Services.Areas.Payments.Models.Payments;
using EstateManagment.Services.Implementation;
using EstateManagment.Services.ServiceModels.Rents;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EstateManagment.Services.Areas.Payments.Implementation
{
    public class PaymentsService : BaseService, IPaymentsService
    {
        private readonly IMonthlyRentsService monthlyRentService;
        public PaymentsService(IMapper mapper, EstateManagmentContext db, IMonthlyRentsService monthlyRentService)
            : base(mapper, db)
        {
            this.monthlyRentService = monthlyRentService;
        }

        public async Task<IEnumerable<PaymentConsumablesListingModel>> AllConsumablePaymentsAsync()
        {
            var payments = await this.Db.Payments
                .Where(x => x.MonthlyPaymentConsumableId != null)
                .OrderByDescending(x => x.PaidOn)
                .ToListAsync();

            var model = Mapper.Map<IEnumerable<PaymentConsumablesListingModel>>(payments);
            return model;
        }

        public async Task<IEnumerable<PaymentRentListingModel>> AllRentPaymentsAsync()
        {
            var payments = await this.Db.Payments
                .Where(x => x.MonthlyPaymentRentId != null)
                .OrderByDescending(x => x.PaidOn)
                .ToListAsync();

            var model = Mapper.Map<IEnumerable<PaymentRentListingModel>>(payments);
            return model; ;
        }

        public async Task<FilterConsumablesViewModel> FilterConsumablesAsync(FilterPaymentsBindingModel bindModel)
        {
            var payments = await this.Db.Payments
                .Where(x => x.MonthlyPaymentConsumableId!=null && x.PaidOn >= bindModel.StartDate && x.PaidOn <= bindModel.EndDate)
                .OrderBy(x=>x.PaidOn)
                .ToListAsync();
            if (payments==null)
            {
                return null;
            }
            if (!bindModel.ShowAll)
            {
                payments =  payments
                    .Where(x => x.MonthlyPaymentConsumable.RentAgreement.ClientId == bindModel.Client)
                    .ToList();
            }
            var paymentsListingModel = Mapper.Map<IEnumerable<PaymentConsumablesListingModel>>(payments);

            var model = new FilterConsumablesViewModel()
            {
                StartDate = bindModel.StartDate,
                EndDate = bindModel.EndDate,
                Payments = paymentsListingModel
            };
            return model;
        }

        public async Task<bool> MakeConsumablesPaymentAsync(int consumableId, bool isCash, string userId)
        {
            var monthlyConsumables = await this.Db.FindAsync<MonthlyPaymentConsumable>(consumableId);
            var user = await this.Db.FindAsync<User>(userId);
            if (user == null || monthlyConsumables == null)
            {
                return false;
            }

            var payment = await this.Db.Payments.AddAsync(new Payment()
            {
                Amount = monthlyConsumables.PaymentForElectricity + monthlyConsumables.PaymentForWater,
                CashPayment = isCash,
                MonthlyPaymentConsumableId = monthlyConsumables.Id,
                PaidOn = DateTime.UtcNow,
                UserId = userId
            });
            try
            {
                await this.Db.SaveChangesAsync();
            }
            catch (Exception)
            {
                return false;
            }

            monthlyConsumables.PaymentId = payment.Entity.Id;
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

        public async Task<bool?> MakePaymentAsync(BindingMonthlyRentModel model, string userId)
        {
            var monthlyRent = await this.Db.FindAsync<MonthlyPaymentRent>(model.MonthlyRentId);
            var user = await this.Db.FindAsync<User>(userId);
            if (monthlyRent == null || user == null)
            {
                return false;
            }
            var sumLeftToBePaid = monthlyRent.TotalPayment - monthlyRent.Payments.Sum(x => x.Amount);
            if (model.Payment == sumLeftToBePaid)
            {
                monthlyRent.IsPaid = true;
            }
            monthlyRent.Payments.Add(new Payment()
            {
                Amount = model.Payment,
                CashPayment = model.CashPayment,
                PaidOn = DateTime.UtcNow,
                UserId = userId
            });
            try
            {
                await this.Db.SaveChangesAsync();
            }
            catch (Exception)
            {
                return false;
            }

            //Create payment for next month
            if (monthlyRent.IsPaid)
            {
                bool nextMonthCreated = await this.monthlyRentService
                    .CreateNextMonthPayment(monthlyRent.Id);
                if (!nextMonthCreated)
                {
                    return null;
                }
            }

            return true;
        }
    }
}
