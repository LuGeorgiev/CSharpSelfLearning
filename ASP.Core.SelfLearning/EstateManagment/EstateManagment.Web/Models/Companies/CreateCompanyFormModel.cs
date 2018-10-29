using EstateManagment.Services.ServiceModels.Companies;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using static EstateManagment.Data.DataConstants;

namespace EstateManagment.Web.Models.Companies
{
    public class CreateCompanyFormModel
    {
        [Required]
        [RegularExpression(RegexLatinNames)]
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

        public IEnumerable<CompanyModel> Companies { get; set; }
    }
}
