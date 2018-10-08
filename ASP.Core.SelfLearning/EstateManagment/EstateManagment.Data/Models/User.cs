
namespace EstateManagment.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;

    using static DataConstants;

    public class User :IdentityUser
    {
        public string Nickname { get; set; }

        public virtual ICollection<Payment> SubmittedRents { get; set; } = new List<Payment>();

        public virtual ICollection<MonthlyPaymentConsumable> SubmittedConsumables { get; set; } = new List<MonthlyPaymentConsumable>();
    }
}
