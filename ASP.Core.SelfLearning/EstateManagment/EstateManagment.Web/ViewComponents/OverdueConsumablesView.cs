using EstateManagment.Services.Areas.Payments;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EstateManagment.Web.ViewComponents
{
    [ViewComponent(Name = "OverdueConsumablesView")]
    public class OverdueConsumablesView : ViewComponent
    {
        private readonly IMonthlyConsumablesService consumables;

        public OverdueConsumablesView(IMonthlyConsumablesService consumables)
        {
            this.consumables = consumables;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await this.consumables.AllOverduConsumablesAsync();

            return View(model);
        }
    }
}
