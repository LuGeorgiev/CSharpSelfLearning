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
        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }

        [Required]
        public int RentAgreementId { get; set; }

        public virtual RentAgreement RentAgreement { get; set; }
    }
}
