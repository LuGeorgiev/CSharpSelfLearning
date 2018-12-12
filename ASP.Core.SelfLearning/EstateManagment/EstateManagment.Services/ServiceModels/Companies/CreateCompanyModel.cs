using System.ComponentModel.DataAnnotations;

using static EstateManagment.Data.Models.DataConstants;

namespace EstateManagment.Services.ServiceModels.Companies
{
    public class CreateCompanyModel
    {
        [Required]
        [RegularExpression(RegexLatinCompanyNames, ErrorMessage = ErrorMessageCompanyName)]
        [MinLength(CompanyNameMinLength)]
        [MaxLength(CompanyNameMaxLength)]
        [Display(Name = DisplayCompanyName)]
        public string Name { get; set; }

        [Required]
        [MinLength(PropertyAddressMinLength)]
        [MaxLength(PropertyAddressMaxLength)]
        [Display(Name = DisplayAddress)]
        public string Address { get; set; }

        [Required]
        [MinLength(CompanyBulstatMinLength)]
        [MaxLength(CompanyBulstatMaxLength)]
        [RegularExpression(RegexBulstat, ErrorMessage = ErrorMessageBulstat)]
        [Display(Name = DisplayBulstat)]
        public string Bulstat { get; set; }

        [Required]
        [RegularExpression(RegexLatinNames, ErrorMessage = ErrorMessageLatinNames)]
        [Display(Name = DisplayAcountablePerson)]
        [MinLength(ClientNameMinLength)]
        [MaxLength(ClientNameMaxLength)]
        public string AccountablePerson { get; set; }
    }
}
