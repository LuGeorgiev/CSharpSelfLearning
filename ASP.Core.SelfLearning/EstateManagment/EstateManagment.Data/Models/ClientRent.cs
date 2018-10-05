namespace EstateManagment.Data.Models
{
    public class ClientRent
    {
        public int ClientId { get; set; }

        public virtual Client Client { get; set; }

        public int RentAgreementId { get; set; }

        public virtual RentAgreement RentAgreement { get; set; }
    }
}
