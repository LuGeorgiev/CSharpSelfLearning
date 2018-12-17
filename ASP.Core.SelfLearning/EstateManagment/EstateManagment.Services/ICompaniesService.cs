﻿using EstateManagment.Services.Models.Companies;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EstateManagment.Services
{
    public interface ICompaniesService
    {
        Task<bool> CreateAsync(string name, string address, string bulstat, string accountablePerson);

        Task<IEnumerable<CompanyModel>> AllAsync();

        Task<CompanyDetailsModel> GetAsync(int companyId);

        Task<bool> EditAsync(int id, string name, string bulstat, string acoutableName, string address);
    }
}
