﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using static EstateManagment.Data.Models.DataConstants;

namespace EstateManagment.Services.Models.Areas.Payments.MonthlyRents
{
    public class MonthlyRentListingModel
    {

        public int Id { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = DisplayDeadLine)]
        public DateTime DeadLine { get; set; } /*= DateTime.UtcNow.AddMonths(1);*/

        [DataType(DataType.Date)]
        [Display(Name = DisplayPaidOn)]
        public DateTime PaidOn { get; set; } = DateTime.UtcNow;

        [Required]
        [Range(typeof(decimal), MinPayment, MaxPayment)]
        [Display(Name = DisplayTotalPayment)]
        public decimal TotalPayment { get; set; }

        public string Client { get; set; }

        public IEnumerable<string> Properties { get; set; }

        [Range(typeof(decimal), MinPayment, MaxPayment)]
        [Display(Name = DisplayPayment)]
        public decimal Payment { get; set; }       

        [Display(Name = DisplayCashPayment)]
        public bool CashPayment { get; set; } = false;

        [Range(InvoiceMinNumber, InvoiceMaxNumber)]
        [Display(Name = DisplayInvoiceNumber)]
        public int? InvoiceNumber { get; set; }

        public int ParkingSlotQuantity { get; set; }

        public int RentAgreementId { get; set; }
    }
}
