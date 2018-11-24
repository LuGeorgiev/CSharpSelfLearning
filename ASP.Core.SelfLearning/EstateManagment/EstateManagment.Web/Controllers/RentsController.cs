using EstateManagment.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using EstateManagment.Web.Models.Rents;
using EstateManagment.Services.ServiceModels.Rents;
using Microsoft.AspNetCore.Http;
using EstateManagment.Web.Common.Extensions;

using static EstateManagment.Web.WebConstants;
using static EstateManagment.Data.DataConstants;

namespace EstateManagment.Web.Controllers
{
    [Authorize(Roles = "Manager, Accountant")]
    public class RentsController : Controller
    {
        private readonly IRentsService rents;
        private readonly IClientsService clients;
        private readonly IPropertiesService properties;

        public RentsController(IRentsService rents, IPropertiesService properties, IClientsService clients)
        {
            this.rents = rents;
            this.properties = properties;
            this.clients = clients;
        }

        public async Task<IActionResult> Index()
        {
            var model = await this.rents.AllAsync();

            return View(model);
        }

        public async Task<IActionResult> Details(int id)
        {
            var model = await this.rents.GetDetailsAsync(id);

            if (model==null)
            {
                return this.BadRequest();
            }
            return View(model);
        }

        public async Task<IActionResult> Create()
        {
            var clients = await this.clients
               .AllAsync();
            IEnumerable<SelectListItem> clientsListItems = clients
                .Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                })
                .ToList();

            var properties = await this.properties.AllFreeAsync();
            IEnumerable<SelectListItem> propertiesListItems = properties
                .Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name+" "+x.Area+", m2"
                })
                .ToList();

            var model = new CreateRentFormViewModel()
            {
                Clients=clientsListItems,
                FreeProperties= propertiesListItems
            };
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = ManagerRole)]
        public async Task<IActionResult> Create(CreateRentModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.Redirect("/Rents/Create");
            }

            bool isCreated = await this.rents.CreateAsync(model);
            if (!isCreated)
            {
                return this.Redirect("/Rents/Create");
            }

            return this.Redirect("/Rents/Index");
        }

        public async Task<IActionResult> Terminate(int id)
        {
            var model = await this.rents.GetDetailsAsync(id);
            if (model==null)
            {
                return Redirect("/Rents/Index");
            }

            return View(model);
        }
          
        [Authorize(Roles = ManagerRole)]
        public async Task<IActionResult> ConfirmTerminate(int id)
        {
            var isTerminated = await this.rents.TerminateAsync(id);
            if (!isTerminated)
            {
                return this.BadRequest();
            }

            return Redirect("/Rents/Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var model = await this.rents.GetDetailsAsync(id);

            if (model == null)
            {
                return this.BadRequest();
            }
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = ManagerRole)]
        public async Task<IActionResult> Edit(string description, string parkingSlotDescription, int id)
        {
            bool isEdited = await this.rents.EditDescriptionsAsync(description, parkingSlotDescription, id);

            if (!isEdited)
            {
                return this.BadRequest();
            }

            return Redirect("/Rents/Index");
        }

        [HttpPost]
        [Authorize(Roles = ManagerRole)]
        public async Task<IActionResult> UploadContract(int id, IFormFile contract)
        {
            if (!contract.FileName.EndsWith(".zip")||contract.Length>ContractsFileMaxSize)
            {
                return RedirectToAction(nameof(Details), new { id });
            }
            var fileContent = await contract.ToByteArrayAsync();
            bool isUloaded = await this.rents.UploadContractAsync(fileContent, id);
            if (!isUloaded)
            {
                return BadRequest();
            }

            return Redirect("/Rents/Index");
        }
    }
}
