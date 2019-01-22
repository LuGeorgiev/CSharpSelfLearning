using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using static EstateManagment.Data.Models.DataConstants;

namespace EstateManagment.Services.Models.Areas.Payments.MonthlyConsumables
{
    public class MonthlyConsumablesListingModel
    {
        public int Id { get; set; }

        [Display(Name = DisplayClientName)]
        public string Client { get; set; }

        [Display(Name = DisplayPropertyName)]
        public IEnumerable<string> Properties { get; set; }

        
        [Range(typeof(decimal), MinPayment, MaxPayment)]
        [Display(Name = DisplayTotalConsumablesMonthlyPrice)]
        public decimal TotalConsumablesMonthlyPrice { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = DisplayDeadLine)]
        public DateTime DeadLine { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = DisplayPaidOn)]
        public DateTime PaidOn { get; set; } = DateTime.UtcNow;

        [Display(Name = DisplayCashPayment)]
        public bool IsCash { get; set; }

        [Range(InvoiceMinNumber, InvoiceMaxNumber)]
        [Display(Name = DisplayInvoiceNumber)]
        public int? InvoiceNumber { get; set; }

        public int RentAgreementId { get; set; }
    }
}
