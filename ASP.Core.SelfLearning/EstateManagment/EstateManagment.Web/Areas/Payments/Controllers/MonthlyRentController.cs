using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstateManagment.Services.Areas.Payments;
using EstateManagment.Services.Areas.Payments.Models.MonthlyRents;
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
            return View(monthlyRent);
        }

        [HttpPost]
        public async Task<IActionResult> Create(decimal totalPayment, DateTime deadLine, int id)
        {
            if (totalPayment<0 )
            {
                return this.View(id);
            }

            bool isCreated = await this.monthlyRents.CreateAsync(id, totalPayment, deadLine);
            if (!isCreated)
            {
                return this.View(id);
            }
            
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
                return this.View(model);
            }

            bool isEdited = await this.monthlyRents.EditAsync(model);
            if (!isEdited)
            {
                //TODO TEEMP msg
            }
            else
            {

            }

            return RedirectToAction("Index");
        }

        [Authorize(Roles = ManagerRole)]
        public async Task<IActionResult> Terminate(int id)
        {
            bool isTerminated = await this.monthlyRents.Terminate(id);
            if (isTerminated)
            {
                //TODO
            }
            else
            {

            }
            return RedirectToAction("Index"); ;
        }

    }
}