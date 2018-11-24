using EstateManagment.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace EstateManagment.Services.ServiceModels.Rents
{
    public class ParkingSlotShortModel
    {
        public ParkingSlotType Type { get; set; }

        public string Quantity { get; set; }

        public decimal Price { get; set; }
    }
}
