using EstateManagment.Services.ServiceModels.Clients;
using EstateManagment.Services.ServiceModels.Rents;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EstateManagment.Services
{
    public interface IClientsService
    {
        Task<IEnumerable<ClientListingModel>> AllAsync();

        Task<bool> CreateAsync(string name, string address, string bulstat, string egn, string accountableName, string contactName, string telephone, string notes);

        Task<ClientViewModel> GetAsync(int id);

        Task<bool> EditAsync(int id, string accountableName, string address, string contactName, string egn, bool isDeleted, string name, string notes, string telephone);

        Task<ClientDetailsModel> GetDetailsAsync(int id);

        Task<int> GetIdByNameAsync(string name);
    }
}
