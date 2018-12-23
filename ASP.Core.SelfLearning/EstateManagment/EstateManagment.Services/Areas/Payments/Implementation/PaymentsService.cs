using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EstateManagment.Data;
using EstateManagment.Data.Models;
using EstateManagment.Services.Implementation;
using Microsoft.EntityFrameworkCore;
using EstateManagment.Data.Models.Enums;
using EstateManagment.Services.Models.Areas.Payments.Payments;
using EstateManagment.Services.Models.Areas.Payments.MonthlyRents;

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

        public async Task<FilterConsumablesViewModel> FilterConsumablesAsync(FilterConsumablesBindingModel bindModel)
        {
            var payments = await this.Db.Payments
                .Where(x => x.MonthlyPaymentConsumableId!=null && x.PaidOn >= bindModel.StartDate && x.PaidOn <= bindModel.EndDate)
                .OrderBy(x=>x.PaidOn)
                .ToListAsync();
            if (payments==null)
            {
                return null;
            }
            if (bindModel.Client!=0)
            {
                payments =  payments
                    .Where(x => x.MonthlyPaymentConsumable.RentAgreement.ClientId == bindModel.Client)
                    .ToList();
            }

            if (bindModel.OnlyCash)
            {
                payments = payments
                    .Where(x => x.CashPayment == true)
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

        public async Task<FilterRentsViewModel> FilterRentsAsync(FilterRentBindingModel bindModel)
        {
            var payments = await this.Db.Payments
                .Where(x => x.MonthlyPaymentRentId != null && x.PaidOn >= bindModel.StartDate && x.PaidOn <= bindModel.EndDate)
                .OrderBy(x=>x.PaidOn)
                .ToListAsync();
            if (payments==null)
            {
                return null;
            }
            if (bindModel.OnlyCash)
            {
                payments = payments
                    .Where(x => x.CashPayment == true)
                    .ToList();
            }
            if (bindModel.Client!=0)
            {
                payments = payments
                    .Where(x => x.MonthlyPaymentRent.RentAgreement.ClientId == bindModel.Client)
                    .ToList();
            }
            if (bindModel.Property!=0)
            {
                payments = payments
                    .Where(x => x.MonthlyPaymentRent.RentAgreement.PropertyRents.Any(p => p.PropertyId == bindModel.Property))
                    .ToList();
            }
            if (bindModel.ParkingArea!=0)
            {
                payments = payments
                    .Where(x => x.MonthlyPaymentRent.RentAgreement.ParkingSlots.All(y => (int)y.Area == bindModel.ParkingArea))
                    .ToList();
            }
            var paymentsListingModel = Mapper.Map<IEnumerable<PaymentRentListingModel>>(payments);

            var model = new FilterRentsViewModel()
            {
                StartDate=bindModel.StartDate,
                EndDate = bindModel.EndDate,
                Payments = paymentsListingModel
            };
            return model;
        }

        public async Task<bool> MakeConsumablesPaymentAsync(int consumableId, bool isCash, DateTime paidOn, string userId)
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
                PaidOn = paidOn,
                UserId = userId,
                CreatedOn=DateTime.UtcNow
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
                PaidOn = model.PaidOn,
                UserId = userId,
                CreatedOn = DateTime.UtcNow
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

        public async Task<MonthlyPaymentStatisticView> MonthIncomeStatistic(DateTime month)
        {
            var payments = await this.Db.Payments
                .Where(x => x.PaidOn.Month == month.Month)
                .ToListAsync();

            var monthlyPaymentRentIds = payments
                .Where(x=>x.MonthlyPaymentRent!=null)
                .Select(x => x.MonthlyPaymentRent.Id)
                .Distinct()
                .ToList();
            var model = new MonthlyPaymentStatisticView()
            {
                MonthToView = month,

                ConsumablesInCash = payments
                    .Where(x => x.MonthlyPaymentConsumableId != null && x.CashPayment)
                    .Sum(x => x.Amount),

                RentInCash = payments
                    .Where(x => x.MonthlyPaymentRentId != null && x.CashPayment)
                    .Sum(x => x.Amount),

                TotalRentPayment = payments
                    .Where(x => x.MonthlyPaymentRentId != null)
                    .Sum(x => x.Amount),

                TotalConsumablesPayment = payments
                    .Where(x => x.MonthlyPaymentConsumableId != null)
                    .Sum(x => x.Amount),

                VAT = payments
                    .Where(x => x.MonthlyPaymentRentId != null && x.MonthlyPaymentRent.ApplyVAT == true)
                    .Sum(x => (x.Amount - x.Amount / 1.2m)),   
                
                IncomeBackParking = Db.MonthlyPaymentRents
                    .Where(x => monthlyPaymentRentIds.Contains(x.Id))
                    .Sum(x => x.RentAgreement
                        .ParkingSlots
                        .Where(y => y.Area == ParkingSlotArea.BackParking)
                        .Sum(y => y.Price * y.Quantity)),

                
                IncomeFronParking = Db.MonthlyPaymentRents
                    .Where(x => monthlyPaymentRentIds.Contains(x.Id))
                    .Sum(x => x.RentAgreement
                        .ParkingSlots
                        .Where(y => y.Area == ParkingSlotArea.FrontParking)
                        .Sum(y => y.Price * y.Quantity)),
                
                IncomeNoReservedParking = Db.MonthlyPaymentRents
                    .Where(x => monthlyPaymentRentIds.Contains(x.Id))
                    .Sum(x => x.RentAgreement
                        .ParkingSlots
                        .Where(y => y.Area == ParkingSlotArea.NoReserved)
                        .Sum(y => y.Price * y.Quantity)),
            };

            return model;
        }
    }
}
