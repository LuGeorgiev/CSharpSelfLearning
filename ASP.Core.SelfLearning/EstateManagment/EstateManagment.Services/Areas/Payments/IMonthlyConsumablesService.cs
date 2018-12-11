using EstateManagment.Services.Areas.Payments.Models.MonthlyConsumables;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EstateManagment.Services.Areas.Payments
{
    public interface IMonthlyConsumablesService
    {
        Task<CreateMonthlyConsumablesModel> GetCreateInfoAsync(int rentId);

        Task<bool> CreateMonthlyConsumable(MonthlyConsumablesBindingModel model);

        Task<IEnumerable<MonthlyConsumablesListingModel>> AllNotPaid();

        Task<MonthlyConsumablesViewModel> GetByIdAsync(int id);

        Task<bool> TerminateAsync(int id);

        Task<bool> EditAsync(EditMontlyConsumablesModel model);


        Task<IEnumerable<OverdueMonthlyConsumablesListingModel>> AllOverduConsumablesAsync();
    }
}
