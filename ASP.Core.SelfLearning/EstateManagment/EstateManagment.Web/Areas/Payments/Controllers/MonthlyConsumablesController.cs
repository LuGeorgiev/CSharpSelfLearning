using System.Threading.Tasks;
using EstateManagment.Services.Areas.Payments;
using EstateManagment.Services.Areas.Payments.Models.MonthlyConsumables;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using static EstateManagment.Web.WebConstants;

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

            return RedirectToAction("Index");
        }

        //public async Task<IActionResult> Pay(int id, bool isCash)
        //{
        //    return View();
        //}

        [Authorize(Roles = ManagerRole)]
        public async Task<IActionResult> Terminate(int id)
        {
            var model = await this.consumables.GetByIdAsync(id);
            if (model==null)
            {
                return this.BadRequest();
            }
            return View(model);
        }

        [Authorize(Roles = ManagerRole)]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await this.consumables.GetByIdAsync(id);
            if (model == null)
            {
                return this.BadRequest();
            }
            return View(model);
        }

        [Authorize(Roles = ManagerRole)]
        public async Task<IActionResult> DoTerminate(int id)
        {
            var model = await this.consumables.GetByIdAsync(id);
            if (model == null)
            {
                return this.BadRequest();
            }
            var isTerminated = await this.consumables.TerminateAsync(id);
            if (!isTerminated)
            {
                return this.BadRequest();
            }

            return RedirectToAction("Index");
        }

        [Authorize(Roles = ManagerRole)]
        [HttpPost]
        public async Task<IActionResult> Edit(EditMontlyConsumablesModel model)
        {            
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }
            var isEdited = await this.consumables.EditAsync(model);
            if (!isEdited)
            {
                return this.View(model);
            }

            return RedirectToAction("Index");
        }
    }
}