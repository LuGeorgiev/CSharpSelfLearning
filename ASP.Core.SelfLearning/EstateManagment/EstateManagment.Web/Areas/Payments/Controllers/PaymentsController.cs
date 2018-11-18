using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EstateManagment.Web.Areas.Payments.Controllers
{
    public class PaymentsController : PaymentsBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}