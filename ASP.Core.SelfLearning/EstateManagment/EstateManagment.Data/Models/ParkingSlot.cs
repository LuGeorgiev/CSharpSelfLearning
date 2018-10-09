namespace EstateManagment.Data.Models
{
    using Enums;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static DataConstants;

    public class ParkingSlot
    {
        public int Id { get; set; }

        public ParkingSlotType Type { get; set; }

        [Required]
        [Range(typeof(decimal), MinPayment, MaxPayment)]
        public decimal Price { get; set; }

        [Required]
        public int CompanyId { get; set; }

        public virtual Company Company { get; set; }

        public virtual ICollection<ParkingSlotRent> ParkingSlotRents { get; set; } = new HashSet<ParkingSlotRent>();

    }
}
