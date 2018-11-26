using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using static EstateManagment.Data.DataConstants;

namespace EstateManagment.Services.Areas.Payments.Models.MonthlyRents
{
    public class MonthlyRentListingModel
    {

        public int Id { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = DisplayDeadLine)]
        public DateTime DeadLine { get; set; } = DateTime.UtcNow.AddMonths(1);

        [Required]
        [Range(typeof(decimal), MinPayment, MaxPayment)]
        [Display(Name = DisplayTotalPayment)]
        public decimal TotalPayment { get; set; }

        public string Client { get; set; }

        public IEnumerable<string> Properties { get; set; }

        [Range(typeof(decimal), MinPayment, MaxPayment)]
        [Display(Name = DisplayPayment)]
        public decimal Payment { get; set; }       

        [Display(Name = DisplayCashPayment)]
        public bool CashPayment { get; set; } = false;

        public int ParkingSlotQuantity { get; set; }
    }
}
