using EstateManagment.Services.Models.Areas.Payments.MonthlyConsumables;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EstateManagment.Services.Areas.Payments
{
    public interface IMonthlyConsumablesService:IInvoiceNumberService
    {
        Task<CreateMonthlyConsumablesModel> GetCreateInfoAsync(int rentId);

        Task<bool> CreateAsync(MonthlyConsumablesBindingModel model);

        Task<IEnumerable<MonthlyConsumablesListingModel>> AllNotPaidAsync();

        Task<MonthlyConsumablesViewModel> GetByIdAsync(int id);

        Task<bool> TerminateAsync(int id);

        Task<bool> EditAsync(EditMontlyConsumablesModel model);

        Task<IEnumerable<OverdueMonthlyConsumablesListingModel>> AllOverduConsumablesAsync();
    }
}
