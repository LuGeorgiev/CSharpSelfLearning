using System.ComponentModel.DataAnnotations;
using static EstateManagment.Data.DataConstants;

namespace EstateManagment.Services.ServiceModels.Rents
{
    public class RentListingViewModel
    {
        public int Id { get; set; }

        [Display(Name = DisplayClientName)]
        public string Client { get; set; }

        [Display(Name = DisplayPropertyName)]
        public string Property { get; set; }
                
        [Display(Name = DisplayPrice)]
        public decimal MonthlyPrice { get; set; }
    }
}
