using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EstateManagment.Data;
using EstateManagment.Services.ServiceModels.MonthlyPaymentRentsService;
using Microsoft.EntityFrameworkCore;

namespace EstateManagment.Services.Implementation
{
    public class MonthlyPaymentRentsService : BaseService, IMonthlyPaymentRentsService
    {
        public MonthlyPaymentRentsService(IMapper mapper, EstateManagmentContext db)
            : base(mapper, db)
        {
        }

        public async Task<IEnumerable<OverdueMontlyRentsListingModel>> AllOverdueRentsAsync()
        {
            var overdueRents = await this.Db.MonthlyPaymentRents
                .Where(x => x.IsPaid == false && x.DeadLine < DateTime.UtcNow)
                .ToListAsync();
            var model = this.Mapper.Map<IEnumerable<OverdueMontlyRentsListingModel>>(overdueRents);
            return model;
        }
    }
}
