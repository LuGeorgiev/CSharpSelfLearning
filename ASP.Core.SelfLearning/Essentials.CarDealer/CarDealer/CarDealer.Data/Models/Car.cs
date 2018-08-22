namespace CarDealer.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Car
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Make { get; set; }

        [Required]
        [MaxLength(30)]
        public string Model { get; set; }

        [Required]
        [Range(typeof(long), "0", "9223372036854775807")]
        public long TravelledDistance { get; set; }

        public ICollection<Sale> Sales { get; set; } = new List<Sale>();
        public ICollection<PartCar> Parts { get; set; } = new List<PartCar>();
    }
}
