using System.ComponentModel.DataAnnotations;

using static EstateManagment.Data.DataConstants;

namespace EstateManagment.Services.ServiceModels.Clients
{
    public class ClientViewModel
    {
        public int Id { get; set; }

        [Required]
        [RegularExpression(RegexLatinCompanyNames, ErrorMessage =ErrorMessageCompanyName)]
        [MinLength(ClientNameMinLength)]
        [MaxLength(ClientNameMaxLength)]
        [Display(Name = DisplayClientName)]
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

        [MaxLength(10)]
        [RegularExpression(RegexEGN, ErrorMessage = ErrorMessageEGN)]
        [Display(Name = DisplayEGN)]
        public string EGN { get; set; }

        [Required]
        [MinLength(ClientNameMinLength)]
        [MaxLength(ClientNameMaxLength)]
        [RegularExpression(RegexLatinNames,ErrorMessage = ErrorMessageLatinNames)]
        [Display(Name = DisplayAcountablePerson)]
        public string AccountableName { get; set; }

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

        [MaxLength(DescriptionMaxLength)]
        [Display(Name = DisplayNotes)]
        public string Notes { get; set; }

        [Display(Name= DisplayIsDeletedClient)]
        public bool IsDeleted { get; set; }
    }
}
