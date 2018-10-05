namespace EstateManagment.Data.Models
{
    using System;
    using System.Collections.Generic;

    public class MonthlyPaymentRent
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        public DateTime DeadLine { get; set; } = DateTime.UtcNow.AddMonths(1);

        public decimal MonthlyPayment { get; set; }

        public bool IsPaid { get; set; } = false;

        public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
    }
}
