namespace EstateManagment.Data.Models
{
    using Enums;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static DataConstants;

    public class Property
    {
        public int Id { get; set; }

        [Required]
        [MinLength(PropertyNameMinLength)]
        [MaxLength(PropertyNameMaxLength)]
        public string Name { get; set; }
        
        [Required]
        [MinLength(PropertyAddressMinLength)]
        [MaxLength(PropertyAddressMaxLength)]
        public string  Address { get; set; }

        [Required]
        [Range(PropertyMinArea,PropertyMaxArea)]
        public int Area { get; set; }

        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        public PropertyType Type { get; set; }

        [Required]
        public int CompanyId { get; set; }

        public virtual Company  Company{ get; set; }

        public virtual ICollection<PropertyRent> PropertyRents { get; set; } = new HashSet<PropertyRent>();
    }
}
