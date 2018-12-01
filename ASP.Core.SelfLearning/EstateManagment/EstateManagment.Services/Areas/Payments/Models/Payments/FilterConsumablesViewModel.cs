using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EstateManagment.Services.Areas.Payments.Models.Payments
{
    public class FilterConsumablesViewModel
    {
        public IEnumerable<PaymentConsumablesListingModel> Payments { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal TotalIncome
        {
            get
            {
                return this.Payments.Sum(x => x.Amount);
            }
        }
    }
}
