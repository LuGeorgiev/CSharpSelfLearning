using System.Threading.Tasks;
using EstateManagment.Services;
using EstateManagment.Services.ServiceModels.Clients;
using EstateManagment.Web.Models.Clients;
using Microsoft.AspNetCore.Mvc;

namespace EstateManagment.Web.Controllers
{
    public class ClientsController : Controller
    {
        private readonly IClientsService clients;

        public ClientsController(IClientsService clients)
        {
            this.clients = clients;
        }

        public async Task<IActionResult> Index()
        {
            var model = await this.clients.AllAsync();
            return View(model);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateClientFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var result = await this.clients.CreateAsync(model.Name, model.Address, model.Bulstat, model.EGN, model.AccountableName, model.ContactName, model.Telephone, model.Notes);
            if (!result)
            {
                return View();
            }

            return Redirect("/Clients/Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var model = await this.clients.GetAsync(id);
            if (model==null)
            {
                return BadRequest();
            }

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ClientEditedFormModel model)
        {
            if (! ModelState.IsValid)
            {
                return Redirect("/Clients/Index");
            }

            bool isEdited = await this.clients.EditAsync(
                model.Id,
                model.AccountableName,
                model.Address,
                model.ContactName,
                model.EGN,
                model.IsDeleted,
                model.Name,
                model.Notes,
                model.Telephone);

            if (!isEdited)
            {
                return BadRequest();
            }

            return Redirect("/Clients/Index");
        }
    }
}