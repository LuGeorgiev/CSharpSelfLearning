using EstateManagment.Services.ServiceModels.MonthlyPaymentRentsService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EstateManagment.Services
{
    public interface IMonthlyPaymentRentsService
    {
        Task<IEnumerable<OverdueMontlyRentsListingModel>> AllOverdueRentsAsync();
    }
}
