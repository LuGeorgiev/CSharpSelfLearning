using AutoMapper;
using EstateManagment.Data;
using EstateManagment.Data.Models;
using EstateManagment.Services;
using EstateManagment.Services.ServiceModels.Companies;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstateManagment.Services.Implementation
{
    public class CompaniesService : ICompaniesService
    {
        private readonly EstateManagmentContext db;
        private readonly IMapper mapper;

        public CompaniesService(EstateManagmentContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<CompanyModel>> AllAsync()
            =>await this.db.Companies.Select(x => new CompanyModel
            {
                Id=x.Id,
                Name = x.Name,
                Address = x.Address,
                Bulstat = x.Bulstat
            })
            .ToListAsync();

        public async Task<bool> CreateAsync(string name, string address, string bulstat, string accountablePerson)
        {
            var newCompany = new Company
            {
                Bulstat=bulstat,
                Address=address,
                AccountablePerson=accountablePerson,
                Name=name,                   
            };

            this.db.Companies.Add(newCompany);

            try
            {
                await this.db.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

            return true;
        }

        public async Task<bool> EditSync(int id, string name, string bulstat, string acoutableName, string address)
        {
            var company = await this.db.Companies
                .FirstOrDefaultAsync(x => x.Id == id);
            if (company==null)
            {
                return false;
            }

            company.AccountablePerson = acoutableName;
            company.Address = address;
            company.Bulstat = bulstat;
            company.Name = name;
            this.db.Companies.Update(company);
            try
            {
                this.db.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public async Task<CompanyDetailsModel> GetAsync(int companyId)
        {
            var company = await this.db.Companies
                .FirstOrDefaultAsync(x => x.Id == companyId);
            if (company==null)
            {
                return null;
            }
            var model = this.mapper.Map<CompanyDetailsModel>(company);

            return model;
        }
    }
}
