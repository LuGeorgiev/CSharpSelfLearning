using EstateManagment.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;

using static EstateManagment.Data.Models.DataConstants;

namespace EstateManagment.Services.ServiceModels.Properties
{
    public class PropertyDetailsModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(PropertyNameMinLength)]
        [MaxLength(PropertyNameMaxLength)]
        [Display(Name= DisplayPropertyName)]
        public string Name { get; set; }

        [Required]
        [MinLength(PropertyAddressMinLength)]
        [MaxLength(PropertyAddressMaxLength)]
        [Display(Name = DisplayAddress)]
        public string Address { get; set; }

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

        [Display(Name = DisplayIsActual)]
        public bool IsActual { get; set; } 
    }
}
