

namespace CarDealer.Web.Models.Cars
{
    using System.ComponentModel.DataAnnotations;

    public class CarFormModel
    {
        [Required]
        [MaxLength(50)]
        public string Make { get; set; }

        [Required]
        [MaxLength(30)]
        public string Model { get; set; }

        [Required]
        [Display(Name = "Travelled Distance")]
        [Range(typeof(long), "0", "9223372036854775807", ErrorMessage ="{2} must be positive number")]
        public long TravelledDistance { get; set; }
    }
}
