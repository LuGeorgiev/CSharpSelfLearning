using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using EstateManagment.Data;
using EstateManagment.Data.Models;
using EstateManagment.Data.Models.Enums;
using EstateManagment.Services.ServiceModels.Properties;

namespace EstateManagment.Services.Implementation
{
    public class PropertiesService : BaseService, IPropertiesService
    {
        public PropertiesService(IMapper mapper, EstateManagmentContext db)
            : base(mapper, db)
        {
        }

        public async Task<IEnumerable<PropertyShortModel>> AllActiveAsync()
        {
            var properties = await this.Db.Properties
           .Where(x => x.IsActual == true)
           .OrderBy(x=>x.Name)
           .ThenByDescending(x=>x.Area)
           .ToListAsync();

            var result = this.Mapper.Map<IEnumerable<PropertyShortModel>>(properties);
            return result;
        }

        public async Task<IEnumerable<PropertyShortModel>> AllFreeAsync()
        {          
            var properties = await this.Db.Properties
            .Where(x => x.IsActual == true &&
            !x.PropertyRents.Any(y => y.RentAgreement.EndDate == null) &&
             x.PropertyRents.All(y => y.RentAgreement.EndDate <= DateTime.UtcNow))
            .ToListAsync();

            var result = this.Mapper.Map<IEnumerable<PropertyShortModel>>(properties);
            return result;
        }

        public async Task<IEnumerable<PropertiesListingModel>> AllWithCompaniesAsync()
            => await this.Db.Companies
                .Where(c => c.Properties.Count > 0)
                .Select(c => new PropertiesListingModel
                {
                    CompanyId = c.Id,
                    CompanyName = c.Name,
                    Properties = c.Properties
                     .Where(p => p.IsActual == true)
                     .Select(p => new PropertyViewModel
                     {
                         Id = p.Id,
                         Address = p.Address,
                         Area = p.Area,
                         Name = p.Name,
                         Description = p.Description
                     })
                     .ToList()
                })
                .ToListAsync();

        public async Task<bool> CreateAsync(int companyId, string propertyName, string propertyAddress, int area, string description, PropertyType type)
        {
            var company = await this.Db.Companies
                .FirstOrDefaultAsync(x => x.Id == companyId);
            if (company == null)
            {
                return false;
            }
            var property = new Property
            {
                Address = propertyAddress,
                Name = propertyName,
                Area = area,
                Description = description,
                Type = type,
                CompanyId = company.Id
            };

            await this.Db.Properties.AddAsync(property);
            try
            {
                await Db.SaveChangesAsync();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> EditAsync(int id, string description, bool isActual)
        {
            var property = await this.Db.Properties
                .FirstOrDefaultAsync(x => x.Id == id);
            if (property == null)
            {
                return false;
            }

            property.IsActual = isActual;
            property.Description = description;
            this.Db.Properties.Update(property);
            try
            {
                await this.Db.SaveChangesAsync();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public async Task<PropertyDetailsModel> GetAsync(int propertyId)
        {
            var property = await this.Db.Properties
                .FirstOrDefaultAsync(x => x.Id == propertyId && x.IsActual == true);
            if (property == null)
            {
                return null;
            }

            return this.Mapper.Map<PropertyDetailsModel>(property);
        }
    }
}
