using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using static EstateManagment.Data.Models.DataConstants;

namespace EstateManagment.Services.Models.Property
{
    public class PropertiesListingModel
    {
        public int CompanyId { get; set; }

        [Required]
        [Display(Name = DisplayCompanyName)]
        public string CompanyName { get; set; }

        public IEnumerable<PropertyViewModel> Properties {get; set;}
    }
}
