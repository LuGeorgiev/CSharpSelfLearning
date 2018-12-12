using EstateManagment.Services.Common.ValidationAttributes;
using System;
using System.ComponentModel.DataAnnotations;

using static EstateManagment.Data.Models.DataConstants;

namespace EstateManagment.Services.Areas.Payments.Models.MonthlyRents
{
    public class BindingMonthlyRentModel
    {
        public int MonthlyRentId { get; set; }

        [Required]
        [Range(typeof(decimal), MinPayment, MaxPayment)]
        [EqualOrLower(nameof(TotalLeft))]
        public decimal Payment { get; set; }

        [Required]
        [Range(typeof(decimal), MinPayment, MaxPayment)]
        public decimal TotalLeft { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime PaidOn { get; set; }

        public bool CashPayment { get; set; }
    }
}
