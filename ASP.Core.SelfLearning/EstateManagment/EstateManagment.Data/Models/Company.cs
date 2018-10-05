namespace EstateManagment.Data.Models
{
    using System.Collections.Generic;

    public class Company
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Bulstat { get; set; }

        public string AccountablePerson { get; set; }

        public virtual ICollection<Property> Properties { get; set; } = new HashSet<Property>();

        public virtual ICollection<ParkingSlot> ParkingSlots { get; set; } = new HashSet<ParkingSlot>();

    }
}
