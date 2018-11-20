using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstateManagment.Data.Models;
using EstateManagment.Services.Areas.Payments;
using EstateManagment.Services.Areas.Payments.Models.MonthlyRents;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EstateManagment.Web.Areas.Payments.Controllers
{
    public class PaymentsController : PaymentsBaseController
    {
        private readonly UserManager<User> userManager;
        private readonly IPaymentsService payments;
        public PaymentsController(UserManager<User> userManager, IPaymentsService payments)
        {
            this.userManager = userManager;
            this.payments = payments;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Pay(BindingMonthlyRentModel model)
        {
            var madeByUser = await this.userManager.GetUserAsync(this.User);
            if (!ModelState.IsValid)
            {
                //ToDO Temp data faliour
                return RedirectToAction("Index", "MonthlyRent");
            }
            var successfulPayment = await this.payments.MakePaymentAsync(model, madeByUser.Id);
            if (!successfulPayment)
            {
                //ToDO Temp data faliour             

                return RedirectToAction("Index", "MonthlyRent");

            }
            return RedirectToAction("Index", "MonthlyRent");
        }

    }
}