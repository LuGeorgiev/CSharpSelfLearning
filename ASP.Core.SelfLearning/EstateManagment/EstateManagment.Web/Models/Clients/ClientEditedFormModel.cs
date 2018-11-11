using System.ComponentModel.DataAnnotations;

using static EstateManagment.Data.DataConstants;

namespace EstateManagment.Web.Models.Clients
{
    public class ClientEditedFormModel
    {

        public int Id { get; set; }

        [Required]
        [RegularExpression(RegexLatinCompanyNames)]
        [MinLength(ClientNameMinLength)]
        [MaxLength(ClientNameMaxLength)]
        [Display(Name = "Име на фирма или клиент")]
        public string Name { get; set; }

        [Required]
        [MinLength(PropertyAddressMinLength)]
        [MaxLength(PropertyAddressMaxLength)]
        [Display(Name = "Адрес")]
        public string Address { get; set; }
                

        [MaxLength(10)]
        [RegularExpression(@"^[0-9]{10}$")]
        [Display(Name = "ЕГН")]
        public string EGN { get; set; }

        [Required]
        [RegularExpression(RegexLatinNames)]
        [MinLength(ClientNameMinLength)]
        [MaxLength(ClientNameMaxLength)]
        [Display(Name = "МОЛ")]
        public string AccountableName { get; set; }

        [Required]
        [RegularExpression(RegexLatinNames, ErrorMessage = "Само букви на кирилица или латиница")]
        [MinLength(ClientContactNameMinLength)]
        [MaxLength(ClientContactNameMaxLength)]
        [Display(Name = "Лице за контакти")]
        public string ContactName { get; set; }

        [Required]
        [RegularExpression(@"^\+?[\d\ -]+$", ErrorMessage = "Позволени са само + в началото последван от цифри,интервали и тирета")]
        [MaxLength(20)]
        [Display(Name = "Телефон")]
        public string Telephone { get; set; }

        [MaxLength(DescriptionMaxLength)]
        [Display(Name = "Бележки")]
        public string Notes { get; set; }

        [Display(Name = "Изтриване на клиент")]
        public bool IsDeleted { get; set; }
    }
}
