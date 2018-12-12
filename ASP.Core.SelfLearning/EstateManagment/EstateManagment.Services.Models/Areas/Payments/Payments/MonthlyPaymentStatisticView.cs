using System;
using System.ComponentModel.DataAnnotations;

namespace EstateManagment.Services.Models.Areas.Payments.Payments
{
    public class MonthlyPaymentStatisticView
    {
        [DataType(DataType.Date)]
        public DateTime MonthToView { get; set; }

        public decimal TotalRentPayment { get; set; }

        public decimal RentInCash { get; set; }

        public decimal VAT { get; set; }

        public decimal IncomeFronParking { get; set; }

        public decimal IncomeBackParking { get; set; }

        public decimal IncomeNoReservedParking { get; set; }

        public decimal TotalConsumablesPayment { get; set; }

        public decimal ConsumablesInCash { get; set; }

    }
}
