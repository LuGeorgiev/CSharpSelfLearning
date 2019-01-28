using EstateManagment.Services;
using EstateManagment.Services.Models.Areas.Payments.MonthlyRents;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstateManagment.Web.ViewComponents
{
    [ViewComponent(Name = "ParkingFilterView")]
    public class ParkingFilterView : ViewComponent
    {
        private readonly IClientsService clients;
        public ParkingFilterView(IClientsService clients)
        {
            this.clients = clients;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = new FilterParkingFormModel();

            var allActiveClients = await this.clients.AllAsync();
            IEnumerable<SelectListItem> clients = allActiveClients
                .Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                })
                .Prepend(new SelectListItem
                {
                    Value = "0",
                    Text = "Всички Клиенти"
                });

            IEnumerable<SelectListItem> parkingSlotTypes = new SelectListItem[]
           {
                new SelectListItem
                {
                    Text ="Всички видове",
                    Value = "0"
                },
                new SelectListItem
                {
                    Text ="Коли",
                    Value = "1"
                },
                new SelectListItem
                {
                    Text ="Рейсове",
                    Value = "2"
                },
                new SelectListItem
                {
                    Text ="Камиони",
                    Value = "3"
                },
                new SelectListItem
                {
                    Text ="Големи камиони",
                    Value = "4"
                },
                new SelectListItem
                {
                    Text ="Автомобилни клетки",
                    Value = "5"
                },
                new SelectListItem
                {
                    Text ="Други",
                    Value = "6"
                },

           };

            model.ActiveClients = clients;
            model.ParkingTypes = parkingSlotTypes;

            return View(model);
        }
    }
}
