using System;
using System.Collections.Generic;
using System.Text;

namespace EstateManagment.Services.Models.Areas.Payments.MonthlyRents
{
    public class ParkingRentMonthView
    {
        public int CarsQty { get; set; } 
        public decimal CarsTotal { get; set; }

        public int BusesQty { get; set; }
        public decimal BusesTotal { get; set; }

        public int TrucksQty { get; set; }
        public decimal TrucksTotal { get; set; }

        public int BigTrucksQty { get; set; }
        public decimal BigTrucksTotal { get; set; }

        public int CarCagesQty { get; set; }
        public decimal CarCagesTotal { get; set; }

        public int OthersQty { get; set; }
        public decimal OthersTotal { get; set; }

        public int SingleTypeQty { get; set; }
        public decimal SingleTypeTotal { get; set; }

        public decimal CashTotal { get; set; }
    }
}
