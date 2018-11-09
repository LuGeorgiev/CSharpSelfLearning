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
        public IEnumerable<PropertyType> Type { get; set; }        

        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public string Address { get; set; }
        
        public string Bulstat { get; set; }
       
        public string AccountablePerson { get; set; }
    }
}
