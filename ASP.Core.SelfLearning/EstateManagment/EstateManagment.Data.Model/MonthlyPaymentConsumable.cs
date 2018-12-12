namespace EstateManagment.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;

    public class MonthlyPaymentConsumable
    {
        public int Id { get; set; }

        [Required]
        [Range(typeof(decimal), MinPayment, MaxPayment)]
        [Display(Name = DisplayWaterPayment)]
        public decimal PaymentForWater { get; set; }

        [Required]
        [Range(typeof(decimal), MinPayment, MaxPayment)]
        [Display(Name = DisplayElectricityPayment)]
        public decimal PaymentForElectricity { get; set; }

        [Range(0, int.MaxValue)]
        [Display(Name = DisplayWaterReport)]
        public int? WaterReport { get; set; }

        [Range(0, int.MaxValue)]
        [Display(Name = DisplayElectricityDay)]
        public int? ElectricityDay { get; set; }

        [Range(0, int.MaxValue)]
        [Display(Name = DisplayElectricityNight)]
        public int? ElectricityNight { get; set; }

        [Range(0, int.MaxValue)]
        [Display(Name = DisplayElectricityPeak)]
        public int? ElectricityPeak { get; set; }


        [DataType(DataType.Date)]
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        [DataType(DataType.Date)]
        [Display(Name = DisplayDeadLine)]
        public DateTime DeadLine { get; set; } = DateTime.UtcNow.AddMonths(1);

        [Required]
        public int RentAgreementId { get; set; }

        public virtual RentAgreement RentAgreement { get; set; }

        
        public int? PaymentId { get; set; }

        public virtual Payment Payment { get; set; }
    }
}
