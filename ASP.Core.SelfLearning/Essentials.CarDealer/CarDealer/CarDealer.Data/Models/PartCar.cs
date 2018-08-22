namespace CarDealer.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;
    
    public class PartCar
    {
        [ForeignKey("Part")]
        public int PartId { get; set; }
        public Part Part { get; set; }

        [ForeignKey("Car")]
        public int CarId { get; set; }
        public Car Car { get; set; }
    }
}
