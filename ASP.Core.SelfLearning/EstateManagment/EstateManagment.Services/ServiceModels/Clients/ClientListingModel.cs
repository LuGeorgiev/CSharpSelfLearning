using System.ComponentModel.DataAnnotations;

using static EstateManagment.Data.DataConstants;

namespace EstateManagment.Services.ServiceModels.Clients
{
    public class ClientListingModel
    {
        public int Id { get; set; }

        [Required]
        [RegularExpression(RegexLatinCompanyNames)]
        [MinLength(ClientNameMinLength)]
        [MaxLength(ClientNameMaxLength)]
        [Display(Name="Име на фирма или клиент")]
        public string Name { get; set; }
        

        [Required]
        [MinLength(CompanyBulstatMinLength)]
        [MaxLength(CompanyBulstatMaxLength)]
        [RegularExpression(RegexBulstat)]
        [Display(Name = "Булстат")]
        public string Bulstat { get; set; }        

        [Required]
        [RegularExpression(RegexLatinNames, ErrorMessage="Само букви на кирилица или латиница")]
        [MinLength(ClientContactNameMinLength)]
        [MaxLength(ClientContactNameMaxLength)]
        [Display(Name="Лице за контакти")]
        public string ContactName { get; set; }

        [Required]
        [RegularExpression(@"^\+?[\d\ -]+$",ErrorMessage ="Позволени са само + в началото последван от цифри,интервали и тирета")]
        [MaxLength(20)]
        [Display(Name="Телефон")]
        public string Telephone { get; set; }

    }
}
