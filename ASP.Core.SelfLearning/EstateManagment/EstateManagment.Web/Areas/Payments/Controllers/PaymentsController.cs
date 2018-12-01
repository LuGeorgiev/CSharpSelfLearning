﻿using System;
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

        public  async Task<IActionResult> IndexConsumables()
        {
            var model = await this.payments.AllConsumablePaymentsAsync();
            return View(model);
        }
        public  async Task<IActionResult> IndexRents()
        {
            var model = await this.payments.AllRentPaymentsAsync();
            return View(model);
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

            if (!successfulPayment.Value)
            {
                //ToDO Temp data faliour   
                return RedirectToAction("Index", "MonthlyRent");
            }
            if (successfulPayment==null)
            {
                //TODO Temp Data NEXT MONTH WAS NOT CREATED
                return RedirectToAction("Index", "MonthlyRent");
            }

            return RedirectToAction("Index", "MonthlyRent");
        }

        [HttpPost]
        public async Task<IActionResult> PayConsumables(int id, bool isCash)
        {
            var madeByUser = await this.userManager.GetUserAsync(this.User);
            var successfulPayment = await this.payments.MakeConsumablesPaymentAsync(id, isCash, madeByUser.Id);

            if (!successfulPayment)
            {
                //ToDO Temp data faliour   
                return RedirectToAction("Index", "MonthlyConsumables");
            }

            //TODO Success
            return RedirectToAction("Index", "MonthlyConsumables");
        }

    }
}