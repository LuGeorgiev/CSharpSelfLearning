

using EstateManagment.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;

using static EstateManagment.Data.DataConstants;

namespace EstateManagment.Web.Models.Properties
{
    public class CreatePropertyModel
    {
        [Required]
        [MinLength(PropertyNameMinLength)]
        [MaxLength(PropertyNameMaxLength)]
        public string PropertyName { get; set; }

        [Required]
        [MinLength(PropertyAddressMinLength)]
        [MaxLength(PropertyAddressMaxLength)]
        public string PropertyAddress { get; set; }

        [Required]
        [Range(PropertyMinArea, PropertyMaxArea)]
        public int Area { get; set; }

        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        public PropertyType Type { get; set; }

        [Required]
        public int CompanyId { get; set; }
    }
}
