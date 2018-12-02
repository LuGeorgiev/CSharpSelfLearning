using EstateManagment.Services.Common.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using static EstateManagment.Data.DataConstants;

namespace EstateManagment.Services.Areas.Payments.Models.Payments
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

        [Display(Name = DisplayShowAll)]
        public bool ShowAll { get; set; } 

        [Required]
        public int Client { get; set; }
    }
}
