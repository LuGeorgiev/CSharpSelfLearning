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
        private readonly IRentsService rentService;
        public PaymentsService(IMapper mapper, EstateManagmentContext db, IRentsService rentService)
            : base(mapper, db)
        {
            this.rentService = rentService;
        }

        public async Task<bool> MakePaymentAsync(BindingMonthlyRentModel model, string userId)
        {
            var monthlyRent = await this.Db.FindAsync<MonthlyPaymentRent>(model.MonthlyRentId);  
            if (monthlyRent == null)
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

            if (monthlyRent.IsPaid&&model.NextMont)
            {
                this.Db.MonthlyPaymentRents.Add(new MonthlyPaymentRent()
                {
                    ApplyVAT=monthlyRent.ApplyVAT,
                    DeadLine = monthlyRent.DeadLine.AddMonths(1),
                    RentAgreementId=monthlyRent.RentAgreementId,
                    TotalPayment=monthlyRent.TotalPayment
                });
                await this.Db.SaveChangesAsync();
            }

            return true;
        }
    }
}
