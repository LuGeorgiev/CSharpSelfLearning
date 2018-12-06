using EstateManagment.Services;
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
        private readonly IMonthlyPaymentRentsService rents;
        public OverdueRentsView(IMonthlyPaymentRentsService rents)
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
