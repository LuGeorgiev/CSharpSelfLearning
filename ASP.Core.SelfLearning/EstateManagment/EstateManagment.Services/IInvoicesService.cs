using EstateManagment.Services.Models.Invoices;
using System.Threading.Tasks;

namespace EstateManagment.Services
{
    public interface IInvoicesService
    {
        Task<InvoiceOutputModel> GetViewModelAsync(InvoiceInputModel model);
    }
}
