namespace EstateManagment.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using static DataConstants;

    public class MonthlyPaymentConsumable
    {
        public int Id { get; set; }

        [Range(0, int.MaxValue)]
        public int? WaterReport { get; set; }

        [Required]
        [Range(typeof(decimal), MinPayment, MaxPayment)]
        public decimal WaterPrice { get; set; }

        [Range(0, int.MaxValue)]
        public int? ElectricityDay { get; set; }

        [Range(0, int.MaxValue)]
        public int? ElectricityNight { get; set; }

        [Range(0, int.MaxValue)]
        public int? ElectricityPeak { get; set; }

        [Required]
        [Range(typeof(decimal), MinPayment, MaxPayment)]
        public decimal ElectricityPrice { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        [DataType(DataType.Date)]
        public DateTime DeadLine { get; set; } = DateTime.UtcNow.AddMonths(1);

        public string UserId { get; set; }

        public virtual User User { get; set; }

        [DataType(DataType.Date)]
        public DateTime? PaymentDate { get; set; }

        [Required]
        public int RentAgreementId { get; set; }

        public virtual RentAgreement RentAgreement { get; set; }
    }
}
