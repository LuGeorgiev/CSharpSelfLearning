using EstateManagment.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

using static EstateManagment.Web.WebConstants;
using EstateManagment.Web.Models.Rents;
using EstateManagment.Services.ServiceModels.Rents;

namespace EstateManagment.Web.Controllers
{
    [Authorize(Roles = "Manager, Accountant")]
    public class RentsController : Controller
    {
        private readonly IRentService rents;
        private readonly IClientsService clients;
        private readonly IPropertiesService properties;
        public RentsController(IRentService rents, IPropertiesService properties, IClientsService clients)
        {
            this.rents = rents;
            this.properties = properties;
            this.clients = clients;
        }

        public async Task<IActionResult> Index(bool isActual)
        {
            var model = await this.rents.AllAsync(isActual);

            return View(model);
        }

        public async Task<IActionResult> Details(int id)
        {          
            

            return View();
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
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Terminate(DateTime endDate)
        {
            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string description, string parkingDescriptionpre)
        {
            return View();
        }

        public async Task<IActionResult> ReSign(int id)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ReSign(string description, string parkingDescriptionpre)
        {
            return View();
        }
    }
}
