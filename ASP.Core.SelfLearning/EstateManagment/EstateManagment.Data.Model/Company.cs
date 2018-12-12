namespace EstateManagment.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;

    public class Company
    {
        public int Id { get; set; }

        [Required]
        [RegularExpression(RegexLatinCompanyNames)]
        [MinLength(CompanyNameMinLength)]
        [MaxLength(CompanyNameMaxLength)]
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

        [Required]
        [RegularExpression(RegexLatinNames)]
        [MinLength(ClientNameMinLength)]
        [MaxLength(ClientNameMaxLength)]
        public string AccountablePerson { get; set; }

        public virtual ICollection<Property> Properties { get; set; } = new HashSet<Property>();

        //public virtual ICollection<ParkingSlot> ParkingSlots { get; set; } = new HashSet<ParkingSlot>();

    }
}
