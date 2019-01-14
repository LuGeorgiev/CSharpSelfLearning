using EstateManagment.Services.Models.Clients;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EstateManagment.Services
{
    public interface IClientsService
    {
        Task<IEnumerable<ClientListingModel>> AllAsync(bool isDeleted = false);

        Task<bool> CreateAsync(string name, string address, string bulstat, string egn, string accountableName, string contactName, string telephone, string notes, string email);

        Task<ClientViewModel> GetAsync(int id);

        Task<bool> EditAsync(int id, string accountableName, string address, string contactName, string egn, bool isDeleted, string name, string notes, string telephone, string email);

        Task<ClientDetailsModel> GetDetailsAsync(int id);

        Task<int> GetIdByNameAsync(string name);

        Task<bool> ResurectAsync(int id);
    }
}
