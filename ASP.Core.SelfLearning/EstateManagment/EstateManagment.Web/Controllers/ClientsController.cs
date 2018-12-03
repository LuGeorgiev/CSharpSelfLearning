using System.Threading.Tasks;
using EstateManagment.Services;
using EstateManagment.Services.ServiceModels.Rents;
using EstateManagment.Web.Models.Clients;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using static EstateManagment.Web.WebConstants;

namespace EstateManagment.Web.Controllers
{
    [Authorize(Roles = "Manager, Accountant")]
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

        [Authorize(Roles = ManagerRole)]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = ManagerRole)]
        [HttpPost]
        public async Task<IActionResult> Create(ClientBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = await this.clients
                .CreateAsync(model.Name, model.Address, model.Bulstat, model.EGN, model.AccountableName, model.ContactName, model.Telephone, model.Notes);
            if (!result)
            {
                return View(model);
            }

            return RedirectToAction("Index");
        }

        [Authorize(Roles = ManagerRole)]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await this.clients.GetAsync(id);
            if (model == null)
            {
                return this.View(model);
            }
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = ManagerRole)]
        public async Task<IActionResult> Edit(ClientEditedFormModel model)
        {
            if (!ModelState.IsValid)
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

        public async Task<IActionResult> Details(int id)
        {
            var model = await this.clients.GetDetailsAsync(id);
            if (model==null)
            {
                return BadRequest();
            }
            return View(model); 
        }

        public async Task<IActionResult> DetailsByName(string name)
        {
            var modelId = await this.clients.GetIdByNameAsync(name);
            if (modelId == 0)
            {
                return BadRequest();
            }
            return RedirectToAction("Details", new { id= modelId});
        }

        public async Task<IActionResult> Resurect()
        {
            var deletedClients = await this.clients.AllAsync(true);
            
            return View(deletedClients);
        }

        
        public async Task<IActionResult> DoResurect(int id)
        {
            bool isResurected = await this.clients.Resurect(id);
            if (!isResurected)
            {
                return this.RedirectToAction("Resurect");
            }

            return RedirectToAction("Index");
        }

    }
}