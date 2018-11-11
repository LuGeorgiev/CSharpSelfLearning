namespace EstateManagment.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static DataConstants;

    public class RentAgreement
    {
        public int Id { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        [MaxLength(RentDescriptionMaxLength)]
        public string Description { get; set; }

        [MaxLength(DescriptionMaxLength)]
        public string ParkingSlotDescription { get; set; }

        public virtual ICollection<PropertyRent> PropertyRents { get; set; } = new HashSet<PropertyRent>();

        public virtual ICollection<ParkingSlot> ParkingSlots { get; set; } = new HashSet<ParkingSlot>();

        public virtual ICollection<ClientRent> ClientRents { get; set; } = new HashSet<ClientRent>();

        public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();

        public virtual ICollection<MonthlyPaymentRent> MonthlyRents { get; set; } = new HashSet<MonthlyPaymentRent>();

        public virtual ICollection<MonthlyPaymentConsumable> MonthlyConsumables { get; set; } = new HashSet<MonthlyPaymentConsumable>();
    }
}
