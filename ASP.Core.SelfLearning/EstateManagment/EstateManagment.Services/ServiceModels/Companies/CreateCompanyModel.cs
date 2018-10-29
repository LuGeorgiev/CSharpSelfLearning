using System.ComponentModel.DataAnnotations;

using static EstateManagment.Data.DataConstants;

namespace EstateManagment.Services.ServiceModels.Companies
{
    public class CreateCompanyModel
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
    }
}
