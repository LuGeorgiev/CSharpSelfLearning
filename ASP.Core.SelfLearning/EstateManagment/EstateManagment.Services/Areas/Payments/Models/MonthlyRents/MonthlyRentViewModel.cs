using System;
using System.ComponentModel.DataAnnotations;

using static EstateManagment.Data.Models.DataConstants;

namespace EstateManagment.Services.Areas.Payments.Models.MonthlyRents
{
    public  class MonthlyRentViewModel
    {
        public int Id { get; set; }
        
        [DataType(DataType.Date)]
        [Display(Name = DisplayDeadLine)]
        public DateTime DeadLine { get; set; } 

        [Required]
        [Range(typeof(decimal), MinPayment, MaxPayment)]
        [Display(Name = DisplayTotalPayment)]
        public decimal TotalPayment { get; set; }
    }
}
