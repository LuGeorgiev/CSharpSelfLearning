using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EstateManagment.Data;
using EstateManagment.Data.Models;
using EstateManagment.Services.Areas.Payments.Models.MonthlyRents;
using EstateManagment.Services.Implementation;
using EstateManagment.Services.ServiceModels.Rents;

namespace EstateManagment.Services.Areas.Payments.Implementation
{
    public class PaymentsService :BaseService, IPaymentsService
    {
        private readonly IMonthlyRentsService monthlyRentService;
        public PaymentsService(IMapper mapper, EstateManagmentContext db, IMonthlyRentsService monthlyRentService)
            : base(mapper, db)
        {
            this.monthlyRentService = monthlyRentService;
        }

        public async Task<bool> MakeConsumablesPaymentAsync(int consumableId, bool isCash, string userId)
        {
            var monthlyConsumables = await this.Db.FindAsync<MonthlyPaymentConsumable>(consumableId);
            var user = await this.Db.FindAsync<User>(userId);
            if (user==null || monthlyConsumables==null)
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
            if (monthlyRent == null || user==null)
            {
                return false;
            }
            var sumLeftToBePaid = monthlyRent.TotalPayment - monthlyRent.Payments.Sum(x => x.Amount);
            if (model.Payment== sumLeftToBePaid)
            {
                monthlyRent.IsPaid = true;
            }
            monthlyRent.Payments.Add(new Payment()
            {
                Amount=model.Payment,
                CashPayment=model.CashPayment,
                PaidOn = DateTime.UtcNow,
                UserId=userId
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
            if (monthlyRent.IsPaid && model.NextMonth)
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
