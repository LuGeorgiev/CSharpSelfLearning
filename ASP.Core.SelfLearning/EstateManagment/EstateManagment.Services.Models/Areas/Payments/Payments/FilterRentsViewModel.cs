using System;
using System.Collections.Generic;
using System.Linq;

namespace EstateManagment.Services.Models.Areas.Payments.Payments
{
    public class FilterRentsViewModel
    {
        public IEnumerable<PaymentRentListingModel> Payments { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal TotalIncome
        {
            get
            {
                return this.Payments.Sum(x => x.Amount);
            }
        }

        public decimal VAT
        {
            get
            {
                return this.Payments
                    .Where(x => x.ApplyVAT == true)
                    .Sum(x => x.Amount-x.Amount/1.2m);
            }
        }

        public decimal PaidInCash
        {
            get
            {
                return this.Payments
                    .Where(x => x.CashPayment == true)
                    .Sum(x => x.Amount);
            }
        }
    }
}
