using EstateManagment.Data;
using EstateManagment.Services.Models.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstateManagment.Web.ViewComponents
{
    [ViewComponent(Name = "ContractsList")]
    public class ContractsListViewComponent : ViewComponent
    {
        private readonly EstateManagmentContext db;

        public ContractsListViewComponent(EstateManagmentContext db)
        {
            this.db = db;
        }

        public async Task<IViewComponentResult> InvokeAsync(int rentId)
        {
            IEnumerable<ContractListingModel> model = await this.db.Contracts
                .Where(x => x.RentAgreementId == rentId && x.IsDeleted == false)
                .OrderByDescending(x=>x.UploadDate)
                .Select(x => new ContractListingModel
                {
                    Id = x.Id,
                    UploadDate = x.UploadDate
                })
                .ToListAsync();

            return View(model);
        }
    }
}
