using System.Collections.Generic;
using System.Threading.Tasks;
using EstateManagment.Data.Models.Enums;
using EstateManagment.Services.Models.Property;

namespace EstateManagment.Services
{
    public interface IPropertiesService
    {
        Task<bool> CreateAsync(int companyId, string propertyName, string propertyAddress, int area, string description, PropertyType type);

        Task<IEnumerable<PropertiesListingModel>> AllWithCompaniesAsync();

        Task<PropertyDetailsModel> GetAsync(int propertyId);

        Task<bool> EditAsync(int id, string description, bool isActual);

        Task<IEnumerable<PropertyShortModel>> AllFreeAsync();
        Task<IEnumerable<PropertyShortModel>> AllActiveAsync();
    }
}
