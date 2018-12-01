using System;
using System.Collections.Generic;
using System.Text;

namespace EstateManagment.Services.Areas.Payments.Models.Payments
{
    public class PaymentConsumablesListingModel
    {        
        public decimal Amount { get; set; }

        public DateTime PaidOn { get; set; } = DateTime.UtcNow;

        public bool CashPayment { get; set; } = false;

        public decimal PaymentForWater { get; set; }

        public decimal PaymentForElectricity { get; set; }

        public DateTime DeadLine { get; set; }

        public string User { get; set; }

        public int RentAgreementId { get; set; }

        public string Client { get; set; }
    }
}
