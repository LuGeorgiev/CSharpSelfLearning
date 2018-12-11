using System.ComponentModel.DataAnnotations;

using static EstateManagment.Data.DataConstants;

namespace EstateManagment.Data.Models.Enums
{   
    public enum ParkingSlotArea
    {
        [Display(Name = DisplayFrontParking)]
        FrontParking = 1,

        [Display(Name = DisplayBackParking)]
        BackParking = 2,

        [Display(Name = DisplayNoReserved)]
        NoReserved = 3
    }
}
