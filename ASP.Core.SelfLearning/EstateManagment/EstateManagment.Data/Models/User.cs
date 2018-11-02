
namespace EstateManagment.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static DataConstants;

    public class User :IdentityUser
    {
        
        [RegularExpression(RegexLatinNames)]
        [MinLength(ClientNameMinLength)]
        [MaxLength(ClientNameMaxLength)]
        public string Nickname { get; set; }

        public virtual ICollection<Payment> SubmittedRentPayments { get; set; } = new List<Payment>();

        public virtual ICollection<MonthlyPaymentConsumable> SubmittedConsumablePayments { get; set; } = new List<MonthlyPaymentConsumable>();
    }
}
