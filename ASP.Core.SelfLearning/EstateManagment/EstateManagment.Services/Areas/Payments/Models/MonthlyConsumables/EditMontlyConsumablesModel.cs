using System;
using System.ComponentModel.DataAnnotations;

using static EstateManagment.Data.Models.DataConstants;

namespace EstateManagment.Services.Areas.Payments.Models.MonthlyConsumables
{
    public class EditMontlyConsumablesModel
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
        [Display(Name = DisplayDeadLine)]
        public DateTime DeadLine { get; set; }
    }
}
