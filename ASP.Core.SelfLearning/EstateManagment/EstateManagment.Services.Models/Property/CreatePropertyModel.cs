using EstateManagment.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;

using static EstateManagment.Data.Models.DataConstants;

namespace EstateManagment.Services.Models.Property
{
    public class CreatePropertyModel
    {
        [Required]
        [MinLength(PropertyNameMinLength)]
        [MaxLength(PropertyNameMaxLength)]
        [Display(Name = DisplayPropertyName)]
        public string PropertyName { get; set; }

        [Required]
        [MinLength(PropertyAddressMinLength)]
        [MaxLength(PropertyAddressMaxLength)]
        [Display(Name = DisplayAddress)]
        public string PropertyAddress { get; set; }

        [Required]
        [Range(PropertyMinArea, PropertyMaxArea)]
        [Display(Name = DisplayArea)]
        public int Area { get; set; }

        [Display(Name = DisplayDescription)]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        [Display(Name = DisplayPropertyType)]
        public PropertyType Type { get; set; }

        [Required]
        public int CompanyId { get; set; }
    }
}
