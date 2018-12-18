using System.Threading.Tasks;
using EstateManagment.Services.Areas.Payments;
using EstateManagment.Services.Models.Areas.Payments.MonthlyConsumables;
using EstateManagment.Web.Common.Extensions;
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
            var model = await this.consumables.AllNotPaidAsync();
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
                TempData.AddErrorMessage(WrongInput);
                return this.View(model);
            }

            var isCreated = await this.consumables.CreateAsync(model);
            if (!isCreated)
            {
                return this.BadRequest();
            }
            TempData.AddSuccessMessage("Успешно въведохте консумативи ");
            return RedirectToAction("Index");
        }
      
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
                TempData.AddErrorMessage("Консумативите не бяха премахнатаи!");
                return RedirectToAction("Index");
            }

            TempData.AddErrorMessage("Консумативите бяха успешно премахнатаи!");
            return RedirectToAction("Index");
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
        [HttpPost]
        public async Task<IActionResult> Edit(EditMontlyConsumablesModel model)
        {            
            if (!ModelState.IsValid)
            {
                TempData.AddErrorMessage(WrongInput);
                return this.View(model);
            }
            var isEdited = await this.consumables.EditAsync(model);
            if (!isEdited)
            {
                TempData.AddErrorMessage("Редакцията не беше успешна");
                return RedirectToAction("Index");
            }
            TempData.AddErrorMessage("Редакцията беше успешна");
            return RedirectToAction("Index");
        }
    }
}