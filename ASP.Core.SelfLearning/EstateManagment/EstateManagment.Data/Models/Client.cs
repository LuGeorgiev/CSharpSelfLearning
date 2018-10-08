namespace EstateManagment.Data.Models
{

    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;

    public class Client
    {
        public int Id { get; set; }

        [Required]
        [RegularExpression(RegexLatinNames)]
        [MinLength(ClientNameMinLength)]
        [MaxLength(ClientNameMaxLength)]
        public string Name { get; set; }
        
        [Required]
        [MinLength(PropertyAddressMinLength)]
        [MaxLength(PropertyAddressMaxLength)]
        public string Address { get; set; }

        [Required]
        [MinLength(CompanyBulstatMinLength)]
        [MaxLength(CompanyBulstatMaxLength)]
        [RegularExpression(RegexBulstat)]
        public string Bulstat { get; set; }

        [MaxLength(10)]
        [RegularExpression(@"^[0-9]{10}$")]
        public string EGN { get; set; }

        [Required]
        [RegularExpression(RegexLatinNames)]
        [MinLength(ClientNameMinLength)]
        [MaxLength(ClientNameMaxLength)]
        public string AccountableName { get; set; }

        [Required]
        [RegularExpression(RegexLatinNames)]
        [MinLength(ClientContactNameMinLength)]
        [MaxLength(ClientContactNameMaxLength)]
        public string ContactName { get; set; }

        [Required]
        [RegularExpression(@"^\+?[\d\ -]+$")]
        public string Telephone { get; set; }

        [MaxLength(DescriptionMaxLength)]
        public string Notes { get; set; }

        public bool IsDeleted { get; set; } = false;

        public virtual ICollection<ClientRent> ClientRents { get; set; } = new HashSet<ClientRent>();
    }
}
