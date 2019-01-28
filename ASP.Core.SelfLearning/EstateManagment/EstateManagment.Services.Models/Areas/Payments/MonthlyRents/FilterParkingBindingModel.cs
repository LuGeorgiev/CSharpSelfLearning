using EstateManagment.Services.Models.Areas.Common.ValidationAttributes;
using System;
using System.ComponentModel.DataAnnotations;

using static EstateManagment.Data.Models.DataConstants;

namespace EstateManagment.Services.Models.Areas.Payments.MonthlyRents
{
    public class FilterParkingBindingModel
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

        public int Client { get; set; }

        public int ParkingType { get; set; }
    }
}
