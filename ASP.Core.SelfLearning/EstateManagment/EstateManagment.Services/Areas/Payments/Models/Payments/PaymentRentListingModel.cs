using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EstateManagment.Services.Areas.Payments.Models.Payments
{
    public class PaymentRentListingModel
    {    
        public decimal Amount { get; set; }

        public DateTime PaidOn { get; set; } 

        public bool CashPayment { get; set; } 

        public string Username { get; set; }
                        
        public DateTime DeadLine { get; set; } 

        public decimal TotalPayment { get; set; }

        public bool ApplyVAT { get; set; }

        public int RentAgreementId { get; set; }

        public string Client { get; set; }
    }
}
