using System;
using System.Collections.Generic;
using System.Linq;

namespace EstateManagment.Services.Models.Areas.Payments.Payments
{
    public class FilterConsumablesViewModel
    {
        public IEnumerable<PaymentConsumablesListingModel> Payments { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string FilterDetails { get; set; }

        public decimal TotalIncome
        {
            get
            {
                return this.Payments.Sum(x => x.Amount);
            }
        }

        public decimal TotalWaterIncome
        {
            get
            {
                return this.Payments.Sum(x => x.PaymentForWater);
            }
        }

        public decimal TotalElectricityIncome
        {
            get
            {
                return this.Payments.Sum(x => x.PaymentForElectricity);
            }
        }
    }
}
