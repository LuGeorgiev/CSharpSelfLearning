using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstateManagment.Services.Areas.Payments;
using EstateManagment.Services.Areas.Payments.Models.MonthlyConsumables;
using Microsoft.AspNetCore.Mvc;

namespace EstateManagment.Web.Areas.Payments.Controllers
{
    public class MonthlyConsumablesController : PaymentsBaseController
    {
        private readonly IMonthlyConsumablesService consumables;

        public MonthlyConsumablesController(IMonthlyConsumablesService consumables)
        {
            this.consumables = consumables;
        }

        public async Task<IActionResult> Index()
        {
            var model = await this.consumables.AllNotPaid();
            return View(model);
        }

        public async Task<IActionResult> Create(int id)
        {
            var model = await this.consumables.GetCreateInfoAsync(id);
            if (model==null)
            {
                return this.BadRequest();
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(MonthlyConsumablesBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            var isCreated = await this.consumables.CreateMonthlyConsumable(model);
            if (!isCreated)
            {
                return this.View(model);
            }

            return View("Index");
        }

        public async Task<IActionResult> Pay(int id, bool isCash)
        {
            return View();
        }

        public async Task<IActionResult> Terminate(int id)
        {
            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            return View();
        }
    }
}