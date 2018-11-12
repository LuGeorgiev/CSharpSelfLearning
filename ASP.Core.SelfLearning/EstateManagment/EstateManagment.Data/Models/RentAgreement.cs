using static EstateManagment.Data.DataConstants;

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
        [Display(Name = DisplayStartDate)]
        public DateTime StartDate { get; set; }

        [Display(Name = DisplayEndDate)]
        public DateTime? EndDate { get; set; }

        [MaxLength(RentDescriptionMaxLength)]
        [Display(Name =DisplayDescription)]
        public string Description { get; set; }

        [MaxLength(DescriptionMaxLength)]
        [Display(Name = DisplayParkingDecription)]
        public string ParkingSlotDescription { get; set; }

        [Display(Name = DisplayIsActual)]
        public bool IsActual { get; set; } = true;

        [Required]
        public int ClientId { get; set; }

        public virtual Client Client { get; set; }

        public virtual ICollection<PropertyRent> PropertyRents { get; set; } = new HashSet<PropertyRent>();

        public virtual ICollection<ParkingSlot> ParkingSlots { get; set; } = new HashSet<ParkingSlot>();

        public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();

        public virtual ICollection<MonthlyPaymentRent> MonthlyRents { get; set; } = new HashSet<MonthlyPaymentRent>();

        public virtual ICollection<MonthlyPaymentConsumable> MonthlyConsumables { get; set; } = new HashSet<MonthlyPaymentConsumable>();
    }
}
