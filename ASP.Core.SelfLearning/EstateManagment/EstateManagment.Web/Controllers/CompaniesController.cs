﻿using EstateManagment.Services;
using EstateManagment.Services.ServiceModels.Companies;
using EstateManagment.Web.Models.Companies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstateManagment.Web.Controllers
{
    [Authorize]
    public class CompaniesController:Controller
    {
        public readonly ICompaniesService companies;

        public CompaniesController(ICompaniesService companies)
        {
            this.companies = companies;
        }

        public async Task<IActionResult> Index()
             => this.View(await GetCompaniesAsync());

        [HttpPost]
        public async Task<IActionResult> Create(CreateCompanyFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            var wasSuccessfullyCreated = await this.companies
                .CreateAsync(model.Name, model.Address, model.Bulstat, model.AccountablePerson);

            if (!wasSuccessfullyCreated)
            {
                return this.View(model);
            }

            var formModel = await GetCompaniesAsync();

            return View("Index", formModel);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var model = await this.companies.GetAsync(id);
            if (model==null)
            {
                return BadRequest();
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CompanyDetailsModel model)
        {           
            if (model == null)
            {
                return BadRequest();
            }

            var result = await this.companies.EditSync(model.Id, model.Name, model.Bulstat, model.AccountablePerson, model.Address);
            if (!result)
            {
                return BadRequest();
            }

            return Redirect("/Companies/Index");
        }

        private async Task<CreateCompanyFormModel> GetCompaniesAsync()
        {
            var companies = await this.companies.AllAsync();
            var formModel = new CreateCompanyFormModel
            {
                Companies = companies
            };

            return formModel;
        }
    }
}
