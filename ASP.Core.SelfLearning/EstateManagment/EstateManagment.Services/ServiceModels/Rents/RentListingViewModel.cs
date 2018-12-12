using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using static EstateManagment.Data.Models.DataConstants;

namespace EstateManagment.Services.ServiceModels.Rents
{
    public class RentListingViewModel
    {
        public int Id { get; set; }

        [Display(Name = DisplayClientName)]
        public string Client { get; set; }

        [Display(Name = DisplayPropertyName)]
        public IEnumerable<string> Properties { get; set; }
                
        public int ParkingSlotQuantity { get; set; }

        [Display(Name = DisplayPrice)]
        public decimal TotalMonthlyPrice { get; set; }
    }
}
