namespace EstateManagment.Data.Models
{
    using System;

    using static DataConstants;

    public class MonthlyPaymentConsumable
    {
        public int Id { get; set; }

        public int? WaterReport { get; set; }

        public decimal WaterPrice { get; set; }

        public int? ElectricityDay { get; set; }

        public int? ElectricityNight { get; set; }

        public int? ElectricityPeak { get; set; }

        public decimal ElectricityPrice { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        public DateTime DeadLine { get; set; } = DateTime.UtcNow.AddMonths(1);

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public DateTime? PaymentDate { get; set; }

        public int RentAgreementId { get; set; }

        public virtual RentAgreement RentAgreement { get; set; }
    }
}
