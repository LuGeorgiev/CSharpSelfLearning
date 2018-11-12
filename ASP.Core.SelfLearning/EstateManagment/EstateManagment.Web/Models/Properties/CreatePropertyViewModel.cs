using EstateManagment.Data.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using static EstateManagment.Data.DataConstants;

namespace EstateManagment.Web.Models.Properties
{
    public class CreatePropertyViewModel
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
        [Display(Name=DisplayPropertyType)]
        public IEnumerable<PropertyType> Type { get; set; }        

        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public string Address { get; set; }
        
        public string Bulstat { get; set; }
       
        public string AccountablePerson { get; set; }
    }
}
