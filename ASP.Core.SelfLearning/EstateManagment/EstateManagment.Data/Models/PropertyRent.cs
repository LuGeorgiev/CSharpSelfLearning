namespace EstateManagment.Data.Models
{
    public class PropertyRent
    {
        public int PropertyId { get; set; }

        public virtual Property Property { get; set; }

        public int RentAgreementId { get; set; }

        public virtual RentAgreement RentAgreement { get; set; }
        
        public decimal MonthlyPrice { get; set; }
    }
}
