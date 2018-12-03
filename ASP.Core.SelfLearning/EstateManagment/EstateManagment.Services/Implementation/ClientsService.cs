using AutoMapper;
using EstateManagment.Data;
using EstateManagment.Data.Models;
using EstateManagment.Services.ServiceModels.Clients;
using EstateManagment.Services.ServiceModels.Rents;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateManagment.Services.Implementation
{
    public class ClientsService : BaseService, IClientsService
    {        
        public ClientsService(EstateManagmentContext db, IMapper mapper)
            :base(mapper,db)
        {
        }

        public async Task<IEnumerable<ClientListingModel>> AllAsync(bool isDeleted=false)
        {
            var clients = await this.Db.Clients
                .Where(x => x.IsDeleted == isDeleted)
                .OrderBy(x=>x.Name)
                .ToListAsync();

            var model = this.Mapper.Map<IEnumerable<ClientListingModel>>(clients);
            return model;
        }

        public async Task<bool> CreateAsync(string name, string address, string bulstat, string egn, string accountableName, string contactName, string telephone, string notes)
        {
            var client = new Client()
            {
                Name=name,
                Address=address,
                Bulstat=bulstat,
                EGN=egn,
                AccountableName=accountableName,
                ContactName=contactName,
                Telephone=telephone,
                Notes=notes                 
            };

            await this.Db.Clients.AddAsync(client);
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

        public async Task<bool> EditAsync(int id, string accountableName, string address, string contactName, string egn, bool isDeleted, string name, string notes, string telephone)
        {
            var client = await this.Db.Clients.
                FirstOrDefaultAsync(x => x.Id == id);

            if (client==null)
            {
                return false;
            }

            client.AccountableName = accountableName;
            client.Address = address;
            client.ContactName = contactName;
            client.EGN = egn;
            client.IsDeleted = isDeleted;
            client.Name = name;
            client.Notes = notes;
            client.Telephone = telephone;

            this.Db.Clients.Update(client);
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

        public async Task<ClientViewModel> GetAsync(int id)
        {
            var client = await this.Db.Clients
                .FirstOrDefaultAsync(x => x.Id == id);
            if (client==null)
            {
                return null;
            }

            var model = this.Mapper.Map<ClientViewModel>(client);

            return model;
        }

        public async Task<ClientDetailsModel> GetDetailsAsync(int id)
        {
            var client = await this.Db.FindAsync<Client>(id);
            if (client==null)
            {
                return null;
            }

            var model = Mapper.Map<ClientDetailsModel>(client);
            return model;
        }

        public async Task<int> GetIdByNameAsync(string name)
        {
            var client = await this.Db.Clients
                .FirstOrDefaultAsync(x => x.Name == name);
            if (client==null)
            {
                return 0;
            }

            return client.Id;
        }

        public async Task<bool> Resurect(int id)
        {
            var client = await this.Db.FindAsync<Client>(id);
            if (client==null || client.IsDeleted==false)
            {
                return false;
            }
            client.IsDeleted = false;
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
    }
}
