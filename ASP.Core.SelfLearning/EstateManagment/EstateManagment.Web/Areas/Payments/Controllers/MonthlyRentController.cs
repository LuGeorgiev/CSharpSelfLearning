using System;
using System.Threading.Tasks;
using EstateManagment.Services.Areas.Payments;
using EstateManagment.Services.Models.Areas.Payments.MonthlyRents;
using EstateManagment.Web.Common.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using static EstateManagment.Web.WebConstants;

namespace EstateManagment.Web.Areas.Payments.Controllers
{
    public class MonthlyRentController : PaymentsBaseController
    {
        private readonly IMonthlyRentsService monthlyRents;

        public MonthlyRentController(IMonthlyRentsService monthlyRents)
        {
            this.monthlyRents = monthlyRents;
        }

        public async Task<IActionResult> Index()
        {
            var model = await this.monthlyRents.AllNotPaidAsync();
            return View(model);
        }

        public async Task<IActionResult> Create(int id)
        {
            var monthlyRent = await this.monthlyRents.GetDetailsAsync(id);
            if (monthlyRent==null)
            {
                return BadRequest();
            }
            return View(monthlyRent);
        }

        [HttpPost]
        public async Task<IActionResult> Create(decimal totalPayment, DateTime deadLine, int id)
        {
            if (totalPayment<0 )
            {
                TempData.AddErrorMessage("Сумата не може да бъде по-малак от нула!");
                return this.View(id);
            }

            bool isCreated = await this.monthlyRents.CreateAsync(id, totalPayment, deadLine);
            if (!isCreated)
            {
                TempData.AddErrorMessage("Месечното задължение за наем не беше създадено!");
                return this.View(id);
            }

            TempData.AddSuccessMessage("Месечното задължение беше успешно създадено!");
            return RedirectToAction("Index");
        }
                
        public async Task<IActionResult> Edit(int id)
        {
            var model = await this.monthlyRents.GetByIdAsync(id);
            if (model==null)
            {
                return this.BadRequest();
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(MonthlyRentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData.AddErrorMessage(WrongInput);
                return this.View(model);
            }

            bool isEdited = await this.monthlyRents.EditAsync(model);
            if (!isEdited)
            {
                TempData.AddErrorMessage("Корекцията на месечния наем не беше успешно!");
                return RedirectToAction("Index");
            }

            TempData.AddSuccessMessage("Корекцията на месечния наем беше успешно!");
            return RedirectToAction("Index");
        }

        [Authorize(Roles = ManagerRole)]
        public async Task<IActionResult> Terminate(int id)
        {
            bool isTerminated = await this.monthlyRents.TerminateAsync(id);
            if (!isTerminated)
            {
                TempData.AddErrorMessage("Премахването на месечния наем не беше успешно!");
                return RedirectToAction("Index");
            }
            TempData.AddSuccessMessage("Премахването на месечния наем беше успешно!");
            return RedirectToAction("Index"); ;
        }

        public async Task<InvoiceBindingModel> SetInvoiceNumber(InvoiceBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData.AddErrorMessage(WrongInput);
                model.Id = 0;
                return model;
            }
            var returnModel = await this.monthlyRents.SentNumberAsync(model);
            if (returnModel == null)
            {
                TempData.AddErrorMessage(WrongInput);
                model.Id = 0;
                return model;
            }

            return returnModel;
        }
    }
}