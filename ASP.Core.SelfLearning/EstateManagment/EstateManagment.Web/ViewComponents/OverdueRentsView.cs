using EstateManagment.Services;
using EstateManagment.Services.Areas.Payments;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstateManagment.Web.ViewComponents
{
    [ViewComponent(Name = "OverdueRentsView")]
    public class OverdueRentsView : ViewComponent
    {
        private readonly IMonthlyRentsService rents;
        public OverdueRentsView(IMonthlyRentsService rents)
        {
            this.rents = rents;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await rents.AllOverdueRentsAsync();

            return View(model);
        }
    }
}
