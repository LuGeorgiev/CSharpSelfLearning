using EstateManagment.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstateManagment.Web.ViewComponents
{
    [ViewComponent(Name = "OverdueConsumablesView")]
    public class OverdueConsumablesView : ViewComponent
    {
        private readonly IMontlyPaymentConsumablesService consumables;

        public OverdueConsumablesView(IMontlyPaymentConsumablesService consumables)
        {
            this.consumables = consumables;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await this.consumables.AllOverduConsumablesAsync();

            return View(model);
        }
    }
}
