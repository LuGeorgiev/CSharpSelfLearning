namespace EstateManagment.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;

    public class Contract
    {
        public int Id { get; set; }

        public DateTime UploadDate { get; set; } = DateTime.UtcNow;

        [Required]
        [MaxLength(ContractsFileMaxSize)]
        public byte[] ScannedContract { get; set; }

        public bool IsDeleted { get; set; } = false;

        public int RentAgreementId { get; set; }

        public virtual RentAgreement RentAgreement { get; set; }
    }
}
