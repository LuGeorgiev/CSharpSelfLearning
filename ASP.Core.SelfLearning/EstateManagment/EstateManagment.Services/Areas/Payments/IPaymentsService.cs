using EstateManagment.Services.Areas.Payments.Models.MonthlyRents;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EstateManagment.Services.Areas.Payments
{
    public interface IPaymentsService
    {
        Task<bool?> MakePaymentAsync(BindingMonthlyRentModel model, string userId);
        Task<bool> MakeConsumablesPaymentAsync(int consumableId, bool isCash, string userId);
    }
}
