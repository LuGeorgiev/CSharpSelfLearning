﻿namespace EstateManagment.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static DataConstants;

    public class PropertyRent
    {
        public int PropertyId { get; set; }

        public virtual Property Property { get; set; }

        public int RentAgreementId { get; set; }

        public virtual RentAgreement RentAgreement { get; set; }        
       
    }
}
