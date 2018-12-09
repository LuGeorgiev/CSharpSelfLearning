using EstateManagment.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

using EstateManagment.Web.Common.Extensions;
using static EstateManagment.Web.WebConstants;

namespace EstateManagment.Web.Controllers
{
    [Authorize(Roles =ManagerRole)]
    public class ContractsController : Controller
    {
        private readonly IContractsService contracts;
        public ContractsController(IContractsService contracts)
        {
            this.contracts = contracts;
        }

        public async Task<IActionResult> Delete(int id)
        {
            var isDeleted = await this.contracts.DeleteAsync(id);
            if (!isDeleted)
            {
                return this.BadRequest();
            }
            TempData.AddSuccessMessage("Договорът беше изтрит успешно!");
            return this.RedirectToAction("Details", "Rents", new { id });
        }
        public async Task<IActionResult> Download(int id)
        {
            var contractContent = await this.contracts.DownloadAsync(id);
            if (contractContent==null)
            {
                return this.BadRequest();
            }

            return File(contractContent,"application/zip","contract.zip");
        }
    }
}
