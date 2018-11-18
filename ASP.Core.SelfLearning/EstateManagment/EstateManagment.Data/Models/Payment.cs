namespace EstateManagment.Data.Models
{
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
        public DateTime PaidOn { get; set; } = DateTime.UtcNow;

        [Display(Name = DisplayCashPayment)]
        public bool CashPayment { get; set; } = false;

        public string UserId { get; set; }

        public virtual User User { get; set; }

    }
}
