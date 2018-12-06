using EstateManagment.Services.ServiceModels.MontlyPaymentConsumablesService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EstateManagment.Services
{
    public interface IMontlyPaymentConsumablesService
    {
        Task<IEnumerable<OverdueMonthlyConsumablesListingModel>> AllOverduConsumablesAsync();
    }
}
