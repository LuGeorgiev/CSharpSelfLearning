using EstateManagment.Services.ServiceModels.Clients;
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

        Task<ClientDetailsModel> GetAsync(int id);
        Task<bool> EditAsync(int id, string accountableName, string address, string contactName, string egn, bool isDeleted, string name, string notes, string telephone);
    }
}
