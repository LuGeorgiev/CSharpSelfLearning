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
    [Authorize]
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


            return this.Redirect("/Properties/Index");
        }
    }
}
