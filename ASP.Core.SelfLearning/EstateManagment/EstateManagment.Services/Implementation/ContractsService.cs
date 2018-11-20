using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EstateManagment.Data;
using EstateManagment.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace EstateManagment.Services.Implementation
{
    public class ContractsService : BaseService, IContractsService
    {
        public ContractsService(IMapper mapper, EstateManagmentContext db) 
            : base(mapper, db)
        {
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var contract = await this.Db.Contracts
                .FirstOrDefaultAsync(x => x.Id == id);
            if (contract == null)
            {
                return false;
            }

            contract.IsDeleted = true;
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

        public async Task<byte[]> DownloadAsync(int id)
            => (await this.Db
            .FindAsync<Contract>(id))?.ScannedContract;            

    }
}
