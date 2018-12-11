using EstateManagment.Services;
using EstateManagment.Services.ServiceModels.Invoices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EstateManagment.Web.Controllers
{
    public class DashboardController :Controller
    {
        private readonly IViewRenderService viewRenderService;
        private readonly IHtmlToPdfConverter htmlToPdfConverter;
        private readonly IInvoicesService invoice;

        public DashboardController(
            IViewRenderService viewRenderService,
            IHtmlToPdfConverter htmlToPdfConverter,
            IInvoicesService invoice)
        {
            this.viewRenderService = viewRenderService;
            this.htmlToPdfConverter = htmlToPdfConverter;
            this.invoice = invoice;
        }

        [HttpGet]
        public async Task<IActionResult> GetPdf(InvoiceInputModel input)
        {
            //TODO service after details are clear
            //var model = this.invoice.GetViewModelAsync(input);
            var model = new InvoiceOutputModel();
            var htmlData = await this.viewRenderService.RenderToStringAsync("~/Views/Dashboard/GetPdf.cshtml", model);
            var fileContents = this.htmlToPdfConverter.Convert(htmlData);

            return this.File(fileContents, "application/pdf");
        }
    }
}
