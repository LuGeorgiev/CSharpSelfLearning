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
        public decimal Amount { get; set; }

        [DataType(DataType.Date)]
        public DateTime PaymentDate { get; set; } = DateTime.UtcNow;

        public string UserId { get; set; }

        public virtual User User { get; set; }

    }
}
