namespace EstateManagment.Data.Models
{
    using EstateManagment.Data.Models.ValidationAttributes;
    using System;
    using System.ComponentModel.DataAnnotations;
    using static DataConstants;

    public class Payment
    {
        public int Id { get; set; }

        [Required]
        [Range(typeof(decimal), MinPayment, MaxPayment)]
        [Display(Name = DisplayAmount)]
        public decimal Amount { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = DisplayPaidOn)]
        public DateTime PaidOn { get; set; } 

        [Display(Name = DisplayCashPayment)]
        public bool CashPayment { get; set; } = false;

        [DataType(DataType.Date)]
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        public string UserId { get; set; }

        public virtual User User { get; set; }

        [XorAttributte(nameof(MonthlyPaymentConsumableId))]
        public int? MonthlyPaymentRentId { get; set; }
        public virtual MonthlyPaymentRent MonthlyPaymentRent { get; set; }

        public int? MonthlyPaymentConsumableId { get; set; }

        public virtual MonthlyPaymentConsumable MonthlyPaymentConsumable { get; set; }

    }
}
