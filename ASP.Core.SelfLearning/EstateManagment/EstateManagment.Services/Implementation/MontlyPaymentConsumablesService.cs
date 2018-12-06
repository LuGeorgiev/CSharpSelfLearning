using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EstateManagment.Data;
using EstateManagment.Services.ServiceModels.MontlyPaymentConsumablesService;
using Microsoft.EntityFrameworkCore;

namespace EstateManagment.Services.Implementation
{
    public class MontlyPaymentConsumablesService : BaseService, IMontlyPaymentConsumablesService
    {
        public MontlyPaymentConsumablesService(IMapper mapper, EstateManagmentContext db) 
            : base(mapper, db)
        {
        }

        public async Task<IEnumerable<OverdueMonthlyConsumablesListingModel>> AllOverduConsumablesAsync()
        {
            var overduConsumables = await this.Db.MonthlyPaymentConsumables
                .Where(x => x.PaymentId == null&& x.DeadLine<DateTime.UtcNow)
                .ToListAsync();

            var model = Mapper.Map<IEnumerable<OverdueMonthlyConsumablesListingModel>>(overduConsumables);
            return model;
        }
    }
}
