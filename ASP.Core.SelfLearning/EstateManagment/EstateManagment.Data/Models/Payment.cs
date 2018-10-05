namespace EstateManagment.Data.Models
{
    using System;

    public class Payment
    {
        public int Id { get; set; }

        public decimal Amount { get; set; }

        public DateTime PaymentDate { get; set; } = DateTime.UtcNow;

        public string UserId { get; set; }

        public virtual User User { get; set; }

    }
}
