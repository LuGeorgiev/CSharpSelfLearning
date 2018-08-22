namespace CarDealer.Web.Models.AccountModels
{
    using System.ComponentModel.DataAnnotations;

    public class LoginWithRecoveryCodeModel
    {
            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Recovery Code")]
            public string RecoveryCode { get; set; }
    }
}
