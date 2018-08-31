
namespace CamaraBazar.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Camera
    {
        public int Id { get; set; }

        public CameraMakeType Make { get; set; }

        [Required]
        [StringLength(100, MinimumLength =3)]
        public string Model { get; set; }

        public decimal Price { get; set; }

        [Range(0,100)]
        public int Quantity { get; set; }

        [Required]
        [Range(1,30)]
        public int MinShutterSpeed { get; set; }

        [Required]
        [Range(2000,8000)]
        public int MaxShutterSpeed { get; set; }
        
        public MinISO MinISO { get; set; }

        [Range(200,409600)]
        public int MaxISO { get; set; }

        public bool IsFullFrame { get; set; }

        [Required]
        [MaxLength(15)]
        public string VideoReslution { get; set; }

        [Required]
        [MaxLength(6000)]
        public string  Description { get; set; }
                
        public LightMetering LightMeterings { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(2000)]
        public string ImageUrl { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }
    }
}
