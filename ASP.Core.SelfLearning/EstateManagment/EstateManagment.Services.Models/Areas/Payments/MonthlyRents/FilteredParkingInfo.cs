using System.Collections.Generic;
using System.Linq;

namespace EstateManagment.Services.Models.Areas.Payments.MonthlyRents
{
    public class FilteredParkingInfo
    {
        public IDictionary<string, ParkingRentMonthView> InfoByMonths { get; set; }

        public string FilterDetails { get; set; }

        public decimal TotalIncome
        {
            get
            {
                decimal sum = 0;
                foreach (var month in this.InfoByMonths)
                {
                    sum += month.Value.BigTrucksTotal + month.Value.BusesTotal + month.Value.CarCagesTotal + month.Value.CarsTotal + month.Value.OthersTotal+ month.Value.TrucksTotal;
                }

                return sum;
            }
        }

        public decimal TotalIncomeCash
        {
            get
            {
                decimal sum = 0;
                foreach (var month in this.InfoByMonths)
                {
                    sum += month.Value.CashTotal;
                }

                return sum;
            }
        }
    }
}
