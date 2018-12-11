namespace EstateManagment.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;

    public class MonthlyPaymentRent
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        [DataType(DataType.Date)]
        [Display(Name = DisplayDeadLine)]
        public DateTime DeadLine { get; set; } = DateTime.UtcNow.AddMonths(1);

        [Required]
        [Range(typeof(decimal), MinPayment, MaxPayment)]
        [Display(Name =DisplayTotalPayment)]
        public decimal TotalPayment { get; set; }

        public bool IsPaid { get; set; } = false;

        [Display(Name =DisplayApplyVat)]
        public bool ApplyVAT { get; set; }

        public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

        [Required]
        public int RentAgreementId { get; set; }

        public virtual RentAgreement RentAgreement { get; set; }
    }
}
