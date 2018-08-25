namespace CarDealer.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Sale
    {
        public int Id { get; set; }

        [Required]
        [Range(0,100)]
        public double Discount { get; set; }

        [ForeignKey("Car")]
        public int CarId { get; set; }
        public virtual Car Car { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
