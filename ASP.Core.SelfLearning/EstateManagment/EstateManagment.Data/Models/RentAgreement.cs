namespace EstateManagment.Data.Models
{
    using System;
    using System.Collections.Generic;

    using static DataConstants;
    public class RentAgreement
    {
        public int Id { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string Description { get; set; }

        public string ParkingSlotDescription { get; set; }

        public virtual ICollection<PropertyRent> PropertyRents { get; set; } = new HashSet<PropertyRent>();

        public virtual ICollection<ParkingSlotRent> ParkingSlotRents { get; set; } = new HashSet<ParkingSlotRent>();

        public virtual ICollection<ClientRent> ClientRents { get; set; } = new HashSet<ClientRent>();

        public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();

        public virtual ICollection<MonthlyPaymentRent> MonthlyRents { get; set; } = new HashSet<MonthlyPaymentRent>();

        public virtual ICollection<MonthlyPaymentConsumable> MonthlyConsumables { get; set; } = new HashSet<MonthlyPaymentConsumable>();
    }
}
