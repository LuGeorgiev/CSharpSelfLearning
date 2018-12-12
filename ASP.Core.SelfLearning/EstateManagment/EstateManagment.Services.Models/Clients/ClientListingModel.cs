using System.ComponentModel.DataAnnotations;

using static EstateManagment.Data.Models.DataConstants;

namespace EstateManagment.Services.Models.Clients
{
    public class ClientListingModel
    {
        public int Id { get; set; }

        [Required]
        [RegularExpression(RegexLatinCompanyNames, ErrorMessage = ErrorMessageCompanyName)]
        [MinLength(ClientNameMinLength)]
        [MaxLength(ClientNameMaxLength)]
        [Display(Name = DisplayClientName)]
        public string Name { get; set; }
        

        [Required]
        [MinLength(CompanyBulstatMinLength)]
        [MaxLength(CompanyBulstatMaxLength)]
        [RegularExpression(RegexBulstat, ErrorMessage = ErrorMessageBulstat)]
        [Display(Name = DisplayBulstat)]
        public string Bulstat { get; set; }        

        [Required]
        [RegularExpression(RegexLatinNames, ErrorMessage = ErrorMessageLatinNames)]
        [MinLength(ClientContactNameMinLength)]
        [MaxLength(ClientContactNameMaxLength)]
        [Display(Name = DisplayContactName)]
        public string ContactName { get; set; }

        [Required]
        [RegularExpression(RegexTelephone, ErrorMessage = ErrorMessageTelephone)]
        [MaxLength(20)]
        [Display(Name = DisplayTelephone)]
        public string Telephone { get; set; }

    }
}
