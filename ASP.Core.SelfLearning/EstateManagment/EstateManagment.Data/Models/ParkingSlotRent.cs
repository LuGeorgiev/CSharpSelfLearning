namespace EstateManagment.Data.Models
{
    public class ParkingSlotRent
    {
        public int ParkingSlotId { get; set; }

        public virtual ParkingSlot ParkingSlot { get; set; }

        public int RentAgreementId { get; set; }

        public virtual RentAgreement RentAgreement { get; set; }

    }
}
