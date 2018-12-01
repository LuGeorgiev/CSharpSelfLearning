using EstateManagment.Data;
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
        private readonly EstateManagmentContext db;

        public ConsumablesFilterView(EstateManagmentContext db)
        {
            this.db = db;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = new FilterConsumablesFormModel();
            IEnumerable<SelectListItem> clients = await this.db.Clients
                .Where(x => x.IsDeleted == false)
                .OrderBy(x => x.Name)
                .Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                })
                .ToListAsync();
            model.ActiveClients = clients;

            return View(model);
        }
    }
}
