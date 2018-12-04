using System;
using System.Threading.Tasks;
using EstateManagment.Data.Models;
using EstateManagment.Services.Areas.Payments;
using EstateManagment.Services.Areas.Payments.Models.MonthlyRents;
using EstateManagment.Services.Areas.Payments.Models.Payments;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;

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

        public  async Task<IActionResult> IndexConsumables(int? page)
        {
            var model = await this.payments.AllConsumablePaymentsAsync();

            var pageNumber = page ?? 1;
            var onePageFromModel = model.ToPagedList(pageNumber, 5);

            return View(onePageFromModel);
        }
        public  async Task<IActionResult> IndexRents(int? page)
        {
            var model = await this.payments.AllRentPaymentsAsync();

            var pageNumber = page ?? 1;
            var onePageFromModel = model.ToPagedList(pageNumber, 5);

            return View(onePageFromModel);
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
        public async Task<IActionResult> PayConsumables(int id, bool isCash, DateTime paidOn)
        {
            var madeByUser = await this.userManager.GetUserAsync(this.User);
            var successfulPayment = await this.payments.MakeConsumablesPaymentAsync(id, isCash,paidOn, madeByUser.Id);

            if (!successfulPayment)
            {
                //ToDO Temp data faliour   
                return RedirectToAction("Index", "MonthlyConsumables");
            }

            //TODO Success
            return RedirectToAction("Index", "MonthlyConsumables");
        }

        public async Task<IActionResult> FilterConsumables(FilterConsumablesBindingModel bindModel)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("IndexConsumables");
            }

            var model = await this.payments.FilterConsumablesAsync(bindModel);
            return View(model);
        }

        public async Task<IActionResult> FilterRents(FilterRentBindingModel bindModel)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("IndexRents");
            }

            var model = await this.payments.FilterRentsAsync(bindModel);
            return View(model);
        }

    }
}