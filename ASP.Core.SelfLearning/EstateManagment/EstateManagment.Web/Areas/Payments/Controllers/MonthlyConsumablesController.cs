using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EstateManagment.Web.Areas.Payments.Controllers
{
    public class MonthlyConsumablesController : PaymentsBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}