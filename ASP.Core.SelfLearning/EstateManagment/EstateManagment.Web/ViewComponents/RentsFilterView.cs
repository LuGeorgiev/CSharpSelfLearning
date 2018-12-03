﻿using EstateManagment.Data.Models.Enums;
using EstateManagment.Services;
using EstateManagment.Services.Areas.Payments.Models.Payments;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstateManagment.Web.ViewComponents
{
    [ViewComponent(Name = "RentsFilterView")]
    public class RentsFilterView : ViewComponent
    {
        private readonly IClientsService clients;
        private readonly IPropertiesService properties;

        public RentsFilterView(IClientsService clients, IPropertiesService properties)
        {
            this.clients = clients;
            this.properties = properties;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = new FilterRentsFormViewModel();

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
            model.ActiveClients = clients;

            var allActiveProperties = await this.properties.AllActiveAsync();
            IEnumerable<SelectListItem> properties = allActiveProperties
                .Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name + "/" + x.Area
                })
                .Prepend(new SelectListItem
                {
                    Value = "0",
                    Text = "Всички имоти"
                });
            model.Properties = properties;

            IEnumerable<SelectListItem> areas = new SelectListItem[] 
            {
                  new SelectListItem
                {
                    Text ="Всички зони",
                    Value = "0"
                },
                new SelectListItem
                {
                    Text =ParkingSlotArea.FrontParking.ToString(),
                    Value = "1"
                },
                 new SelectListItem
                {
                    Text =ParkingSlotArea.BackParking.ToString(),
                    Value = "2"
                },
                  new SelectListItem
                {
                    Text =ParkingSlotArea.NoReserved.ToString(),
                    Value = "3"
                },
                 
            };
            model.ParkingAreas = areas;

            return View(model);
        }
    }
}