using EstateManagment.Services.Models.Invoices;
using System;
using System.Threading.Tasks;

namespace EstateManagment.Services.Implementation
{
    public class InvoicesService : IInvoicesService
    {
        public Task<InvoiceOutputModel> GetViewModelAsync(InvoiceInputModel model)
            => throw new InvalidOperationException("Not impelmented");
        
    }
}
