using EstateManagment.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;

using static EstateManagment.Data.Models.DataConstants;

namespace EstateManagment.Services.ServiceModels.Rents
{
    public class ParkingSlotShortModel
    {
        [Display(Name =DisplayParkingSlotType)]
        public ParkingSlotType Type { get; set; }

        public string Quantity { get; set; }

        public decimal Price { get; set; }

        [Display(Name =DisplayParkingSoltArea)]
        public ParkingSlotArea Area { get; set; }
    }
}
