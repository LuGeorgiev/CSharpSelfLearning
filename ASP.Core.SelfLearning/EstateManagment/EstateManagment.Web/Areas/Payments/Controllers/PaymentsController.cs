using System;
using System.Threading.Tasks;
using EstateManagment.Data.Models;
using EstateManagment.Services.Areas.Payments;
using EstateManagment.Services.Models.Areas.Payments.MonthlyRents;
using EstateManagment.Services.Models.Areas.Payments.Payments;
using EstateManagment.Web.Common.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

using static EstateManagment.Web.WebConstants;

namespace EstateManagment.Web.Areas.Payments.Controllers
{
    public class PaymentsController : PaymentsBaseController
    {
        private const int PageSize = 20;

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
            var onePageFromModel = model.ToPagedList(pageNumber, PageSize);

            return View(onePageFromModel);
        }

        public  async Task<IActionResult> IndexRents(int? page)
        {
            var model = await this.payments.AllRentPaymentsAsync();

            var pageNumber = page ?? 1;
            var onePageFromModel = model.ToPagedList(pageNumber, PageSize);

            return View(onePageFromModel);
        }

        [HttpPost]
        public async Task<IActionResult> Pay(BindingMonthlyRentModel model)
        {
            var madeByUser = await this.userManager.GetUserAsync(this.User);
            if (!ModelState.IsValid)
            {
                TempData.AddErrorMessage(WrongInput);
                return RedirectToAction("Index", "MonthlyRent");
            }

            var successfulPayment = await this.payments.MakePaymentAsync(model, madeByUser.Id);

            if (!successfulPayment.Value)
            {
                TempData.AddErrorMessage("Плащането на наем не беше успешно!");
                return RedirectToAction("Index", "MonthlyRent");
            }
            if (successfulPayment==null)
            {
                TempData.AddErrorMessage("Плащането на наема БЕШЕ успешно, но прехвърляното за следващ месец се провали!");
                return RedirectToAction("Index", "MonthlyRent");
            }

            TempData.AddSuccessMessage("Плащането на наем беше успешно!");
            return RedirectToAction("Index", "MonthlyRent");
        }

        [HttpPost]
        public async Task<IActionResult> PayConsumables(int id, bool isCash, DateTime paidOn)
        {
            var madeByUser = await this.userManager.GetUserAsync(this.User);
            var successfulPayment = await this.payments.MakeConsumablesPaymentAsync(id, isCash, paidOn, madeByUser.Id);
            if (!successfulPayment)
            {
                TempData.AddErrorMessage("Плащането на консумативите не беше успешно!");
                return RedirectToAction("Index", "MonthlyConsumables");
            }

            TempData.AddSuccessMessage("Плащането на консумативите беше успешно!");
            return RedirectToAction("Index", "MonthlyConsumables");
        }

        public async Task<IActionResult> FilterConsumables(FilterConsumablesBindingModel bindModel)
        {
            if (!ModelState.IsValid)
            {
                TempData.AddErrorMessage(WrongInput);
                return RedirectToAction("IndexConsumables");
            }

            var model = await this.payments.FilterConsumablesAsync(bindModel);
            TempData.AddSuccessMessage(model.FilterDetails);
            return View(model);
        }

        public async Task<IActionResult> FilterRents(FilterRentBindingModel bindModel)
        {
            if (!ModelState.IsValid)
            {
                TempData.AddErrorMessage(WrongInput);
                return RedirectToAction("IndexRents");
            }

            var model = await this.payments.FilterRentsAsync(bindModel);
            TempData.AddSuccessMessage(model.FilterDetails);
            return View(model);
        }

        public async Task<MonthlyPaymentStatisticView> MonthlyStatistic(DateTime month)
        {
            var model = await this.payments.MonthIncomeStatistic(month);

            return model;
        }

    }
}