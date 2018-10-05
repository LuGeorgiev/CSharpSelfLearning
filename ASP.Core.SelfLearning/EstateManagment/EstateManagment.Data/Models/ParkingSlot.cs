namespace EstateManagment.Data.Models
{
    using Enums;
    using System.Collections.Generic;

    public class ParkingSlot
    {
        public int Id { get; set; }

        public ParkingSlotType Type { get; set; }

        public decimal Price { get; set; }

        public int CompanyId { get; set; }

        public virtual Company Company { get; set; }

        public virtual ICollection<ParkingSlotRent> ParkingSlotRents { get; set; } = new HashSet<ParkingSlotRent>();

    }
}
