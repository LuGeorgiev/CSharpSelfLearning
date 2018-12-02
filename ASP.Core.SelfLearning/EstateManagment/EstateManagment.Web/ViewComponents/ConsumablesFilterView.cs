using EstateManagment.Data;
using EstateManagment.Services;
using EstateManagment.Web.Areas.Payments.Models.Payments;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
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
                });

            model.ActiveClients = clients;

            return View(model);
        }
    }
}
