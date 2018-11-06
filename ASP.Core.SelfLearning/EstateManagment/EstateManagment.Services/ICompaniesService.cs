using EstateManagment.Services.ServiceModels.Companies;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EstateManagment.Services
{
    public interface ICompaniesService
    {
        Task<bool> CreateAsync(string name, string address, string bulstat, string accountablePerson);

        Task<IEnumerable<CompanyModel>> AllAsync();
    }
}
