﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using static EstateManagment.Data.Models.DataConstants;

namespace EstateManagment.Services.Models.Areas.Payments.MonthlyRents
{
    public class CreateMonthlyRentFormViewModel
    {

        [DataType(DataType.Date)]
        [Display(Name = DisplayDeadLine)]
        public DateTime DeadLine { get; set; } = DateTime.UtcNow.AddMonths(1);

        [Required]
        [Range(typeof(decimal), MinPayment, MaxPayment)]
        [Display(Name = DisplayTotalPayment)]
        public decimal TotalPayment { get; set; }
               
        
        [Required]
        public int RentAgreementId { get; set; }

        public string Client { get; set; }

        public IEnumerable<string> Properties { get; set; }

        public int ParkingSlotsQty { get; set; }
    }
}