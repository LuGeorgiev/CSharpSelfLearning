using EstateManagment.Services.Models.Areas.Common.ValidationAttributes;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using static EstateManagment.Data.Models.DataConstants;

namespace EstateManagment.Services.Models.Areas.Payments.MonthlyRents
{
    public class FilterParkingFormModel
    {
        [Required]
        [Display(Name = DisplayStartDate)]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; } = DateTime.UtcNow.AddMonths(-3);

        [Required]
        [Display(Name = DisplayEndDate)]
        [DataType(DataType.Date)]
        [AfterDate(nameof(StartDate))]
        public DateTime EndDate { get; set; } = DateTime.UtcNow;

        [Display(Name = DisplayActiveClients)]
        public IEnumerable<SelectListItem> ActiveClients { get; set; }

        public SelectListItem Client { get; set; }

        [Display(Name = DisplayParkingSlotTypes)]
        public IEnumerable<SelectListItem> ParkingTypes { get; set; }

        public SelectListItem ParkingType { get; set; }
    }
}
