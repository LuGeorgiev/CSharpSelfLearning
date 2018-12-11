using EstateManagment.Services.Common.ValidationAttributes;
using System;
using System.ComponentModel.DataAnnotations;

using static EstateManagment.Data.DataConstants;

namespace EstateManagment.Services.Areas.Payments.Models.Payments
{
    public class FilterRentBindingModel
    {
        [Required]
        [Display(Name = DisplayStartDate)]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; } 

        [Required]
        [Display(Name = DisplayEndDate)]
        [DataType(DataType.Date)]
        [AfterDate(nameof(StartDate))]
        public DateTime EndDate { get; set; } 
              

        [Required]
        public int Client { get; set; }
                

        [Required]
        public int Property { get; set; }

        public bool OnlyCash { get; set; }

        [Required]
        public int ParkingArea { get; set; }
    }
}
