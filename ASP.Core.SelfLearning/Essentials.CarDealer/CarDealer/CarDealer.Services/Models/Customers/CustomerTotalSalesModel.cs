

namespace CarDealer.Services.Models.Customers
{
    using Models.Sales;
    using System.Collections.Generic;
    using System.Linq;

    public class CustomerTotalSalesModel
    {
        public string Name { get; set; }

        public bool IsYoungDriver { get; set; }

        public IEnumerable<SaleModel> BoughtCars { get; set; }

        public decimal TotalSpentMoney
            => this.BoughtCars
                    .Sum(c => c.Price * (1 - (decimal)c.Discount))
                    *(this.IsYoungDriver?0.95m:1);           
    }
}
