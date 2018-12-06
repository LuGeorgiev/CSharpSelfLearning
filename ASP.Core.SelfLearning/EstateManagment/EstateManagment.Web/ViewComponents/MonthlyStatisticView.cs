using EstateManagment.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstateManagment.Web.ViewComponents
{
    [ViewComponent(Name = "MonthlyStatisticView")]
    public class MonthlyStatisticView : ViewComponent
    {

        public MonthlyStatisticView()
        {
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {

            return View();
        }
    }
}
