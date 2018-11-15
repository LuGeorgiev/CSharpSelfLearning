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
        public DateTime DeadLine { get; set; } = DateTime.UtcNow.AddMonths(1);

        [Required]
        [Range(typeof(decimal), MinPayment, MaxPayment)]
        public decimal MonthlyPayment { get; set; }

        public bool IsPaid { get; set; } = false;

        public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

        [Required]
        public int RentAgreementId { get; set; }

        public virtual RentAgreement RentAgreement { get; set; }
    }
}
