using EstateManagment.Services.ServiceModels.Rents;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EstateManagment.Services
{
    public interface IRentService
    {
        Task<IEnumerable<RentListingViewModel>> AllAsync(bool isActual);
        Task<bool> CreateAsync(CreateRentModel model);
    }
}
