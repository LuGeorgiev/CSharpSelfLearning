using AutoMapper;
using EstateManagment.Data;
using EstateManagment.Data.Models;
using EstateManagment.Services.Areas.Payments.Models.MonthlyConsumables;
using EstateManagment.Services.Implementation;
using Microsoft.EntityFrameworkCore;
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
    }
}
