using EstateManagment.Services.Models.Areas.Common.ValidationAttributes;
using System;
using System.ComponentModel.DataAnnotations;

using static EstateManagment.Data.Models.DataConstants;

namespace EstateManagment.Services.Models.Areas.Payments.Payments
{
    public class FilterConsumablesBindingModel
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

       
        public bool OnlyCash { get; set; } 

        [Required]
        public int Client { get; set; }
    }
}
