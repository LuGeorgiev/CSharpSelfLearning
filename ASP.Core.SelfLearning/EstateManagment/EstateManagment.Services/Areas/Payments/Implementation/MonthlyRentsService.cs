using AutoMapper;
using EstateManagment.Data;
using EstateManagment.Data.Models;
using EstateManagment.Services.Areas.Payments.Models.MonthlyRents;
using EstateManagment.Services.Implementation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                .Where(x => x.IsPaid == false)
                .OrderBy(x => x.DeadLine)
                .ToListAsync();

            var notPaidModel = this.Mapper.Map<IEnumerable<MonthlyRentListingModel>>(notPaid);
            return notPaidModel;
        }

        public async Task<bool> CreateAsync(int idRentAgreement, decimal totalPayment, DateTime deadLine, bool applyVat)
        {
            var rentAgreement = await this.Db.FindAsync<RentAgreement>(idRentAgreement);
            if (rentAgreement==null)
            {
                return false;
            }

            if (applyVat==true)
            {
                totalPayment *= 1.20m;
            }

            rentAgreement.MonthlyRents.Add(new MonthlyPaymentRent()
            {
                DeadLine=deadLine,
                ApplyVAT=applyVat,
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
                TotalPayment = monthlyRent.TotalPayment
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

        public async Task<bool> Terminate(int id)
        {
            var monthlyRent = await this.Db
               .FindAsync<MonthlyPaymentRent>(id);

            if (monthlyRent == null || monthlyRent.IsPaid == true)
            {
                return false;
            }
            monthlyRent.IsPaid = true;
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
    }
}
