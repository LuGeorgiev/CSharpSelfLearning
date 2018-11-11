using AutoMapper;
using EstateManagment.Services;
using EstateManagment.Web.Models.Properties;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstateManagment.Web.Controllers
{
    [Authorize(Roles =WebConstants.ManagerRole)]
    public class PropertiesController : Controller
    {
        private readonly IPropertiesService properties;
        private readonly ICompaniesService companies;
        private readonly IMapper mapper;
 
        public PropertiesController(IPropertiesService properties, ICompaniesService companies, IMapper mapper)
        {
            this.properties = properties;
            this.companies = companies;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var model = await this.properties.AllAsync();

            return View(model);
        }

        public async Task<IActionResult> Create(int companyId)
        {
            var company = await this.companies.GetAsync(companyId);
            if (company == null)
            {
                return this.BadRequest();
            }

            var model = mapper.Map<CreatePropertyViewModel>(company);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePropertyModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.Redirect("/Properties/Index");
            }

            var isCreated = await this.properties.CreateAsync(
                model.CompanyId,
                model.PropertyName,
                model.PropertyAddress,
                model.Area,
                model.Description,
                model.Type);

            if (!isCreated)
            {
                return BadRequest();
            }


            return this.Redirect("/Properties/Index");
        }
               

        public async Task<IActionResult> Edit(int id)
        {
            var model = await this.properties.GetAsync(id);
            if (model==null)
            {
                return BadRequest();
            }

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, string description, bool isActual)
        {            
            bool result = await this.properties.EditAsync(id, description, isActual);
            if (!result)
            {
                return BadRequest();
            }

            return this.Redirect("/Properties/Index");
        }
    }
}
