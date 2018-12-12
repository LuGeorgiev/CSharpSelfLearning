
using EstateManagment.Services.Models.Areas.Payments.MonthlyRents;
using EstateManagment.Services.Models.Areas.Payments.Payments;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EstateManagment.Services.Areas.Payments
{
    public interface IPaymentsService
    {
        Task<bool?> MakePaymentAsync(BindingMonthlyRentModel model, string userId);

        Task<bool> MakeConsumablesPaymentAsync(int consumableId, bool isCash, DateTime paidOn, string userId);

        Task<IEnumerable<PaymentRentListingModel>> AllRentPaymentsAsync();

        Task<IEnumerable<PaymentConsumablesListingModel>> AllConsumablePaymentsAsync();

        Task<FilterConsumablesViewModel> FilterConsumablesAsync(FilterConsumablesBindingModel model);

        Task<FilterRentsViewModel> FilterRentsAsync(FilterRentBindingModel bindModel);

        Task<MonthlyPaymentStatisticView> MonthIncomeStatistic(DateTime month);
    }
}
