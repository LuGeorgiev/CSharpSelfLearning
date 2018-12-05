using EstateManagment.Services;
using EstateManagment.Services.Areas.Payments.Models.Payments;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstateManagment.Web.ViewComponents
{
    [ViewComponent(Name = "ConsumablesFilterView")]
    public class ConsumablesFilterView : ViewComponent
    {
        private readonly IClientsService clients;

        public ConsumablesFilterView(IClientsService clients)
        {
            this.clients = clients;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = new FilterConsumablesFormModel();

            var allActiveClients = await this.clients.AllAsync();

            IEnumerable<SelectListItem> clients = allActiveClients
                .Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                })
                .Prepend( new SelectListItem
                {
                    Value = "0",
                    Text = "Всички клиенти"
                });
            

            model.ActiveClients = clients;

            return View(model);
        }
    }
}
