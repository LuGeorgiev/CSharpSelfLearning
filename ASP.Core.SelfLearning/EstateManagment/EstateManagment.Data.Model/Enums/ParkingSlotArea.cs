using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using static EstateManagment.Data.Models.DataConstants;

namespace EstateManagment.Data.Models.Enums
{   
    public enum ParkingSlotArea
    {
        [Description(DisplayFrontParking)]
        [Display(Name = DisplayFrontParking)]
        FrontParking = 1,

        [Display(Name = DisplayBackParking)]
        [Description(DisplayBackParking)]
        BackParking = 2,

        [Display(Name = DisplayNoReserved)]
        [Description(DisplayNoReserved)]
        NoReserved = 3
    }
}
