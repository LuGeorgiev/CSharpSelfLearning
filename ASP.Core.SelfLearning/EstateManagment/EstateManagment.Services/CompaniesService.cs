using EstateManagment.Data;
using EstateManagment.Data.Models;
using EstateManagment.Services.Contracts;
using EstateManagment.Services.ServiceModels.Companies;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstateManagment.Services
{
    public class CompaniesService : ICompaniesService
    {
        private readonly EsteteManagmentContext db;

        public CompaniesService(EsteteManagmentContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<CompanyModel>> AllAsync()
            =>await this.db.Companies.Select(x => new CompanyModel
            {
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
    }
}
