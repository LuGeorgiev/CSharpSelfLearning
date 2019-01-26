using EstateManagment.Services.Models.Areas.Payments.MonthlyRents;
using System.Threading.Tasks;

namespace EstateManagment.Services.Areas.Payments
{
    public interface IInvoiceNumberService
    {
        Task<InvoiceBindingModel> SentNumberAsync(InvoiceBindingModel model);
    }
}
