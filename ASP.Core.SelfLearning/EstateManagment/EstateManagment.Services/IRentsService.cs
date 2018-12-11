using EstateManagment.Services.ServiceModels.Rents;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EstateManagment.Services
{
    public interface IRentsService
    {
        Task<IEnumerable<RentListingViewModel>> AllAsync(bool isActual=true);

        Task<bool> CreateAsync(CreateRentModel model);

        Task<RentDetailsModel> GetDetailsAsync(int id);

        Task<bool> TerminateAsync(int id);

        Task<bool> EditDescriptionsAsync(string description, string parkingSlotDescription, int id);

        Task<bool> UploadContractAsync(byte[] fileContent, int id);
    }
}
