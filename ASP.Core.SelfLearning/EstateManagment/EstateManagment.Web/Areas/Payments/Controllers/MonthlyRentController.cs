using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstateManagment.Services.Areas.Payments;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> Create(bool applyVat, decimal totalPayment, DateTime deadLine, int id)
        {
            if (totalPayment<0 )
            {
                return this.BadRequest();
            }

            bool isCreated = await this.monthlyRents.CreateAsync(id, totalPayment, deadLine, applyVat);
            if (!isCreated)
            {
                return this.BadRequest();
            }
            
            return RedirectToAction("Index");
        }

    }
}