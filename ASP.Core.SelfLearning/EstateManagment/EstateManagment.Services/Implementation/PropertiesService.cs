using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EstateManagment.Data;
using EstateManagment.Data.Models;
using EstateManagment.Data.Models.Enums;
using EstateManagment.Services.ServiceModels.Properties;
using Microsoft.EntityFrameworkCore;

namespace EstateManagment.Services.Implementation
{
    public class PropertiesService : IPropertiesService
    {
        private readonly EstateManagmentContext db;

        public PropertiesService(EstateManagmentContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<PropertiesListingModel>> AllAsync()
            => await this.db.Companies
                .Where(c=>c.Properties.Count>0)
                .Select(c => new PropertiesListingModel
                {
                     CompanyId=c.Id,
                     CompanyName=c.Name,
                     Properties = c.Properties
                     .Where(p=>p.IsActual==true)
                     .Select(p=> new PropertyViewModel
                     {
                         Id=p.Id,
                         Address=p.Address,
                         Area=p.Area,
                         Name=p.Name,
                         Description=p.Description
                     })
                     .ToList()
                })
                .ToListAsync();         

        public async Task<bool> CreateAsync(int companyId, string propertyName, string propertyAddress, int area, string description, PropertyType type)
        {
            var company = await this.db.Companies
                .FirstOrDefaultAsync(x => x.Id == companyId);
            if (company==null)
            {
                return false;
            }
            var property = new Property
            {
                 Address=propertyAddress,
                 Name=propertyName,
                 Area=area,
                 Description=description,
                 Type=type,
                 CompanyId=company.Id
            };

            await this.db.Properties.AddAsync(property);
            try
            {
                await db.SaveChangesAsync();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}
