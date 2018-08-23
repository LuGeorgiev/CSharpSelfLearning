
namespace CarDealer.Web.Models.Customers
{
    using Services.Models.Customers;

    public class CustomerSales 
    {
        public string Name { get; set; }

        public int BoughtCars { get; set; }

        public decimal TotalSpentMoney { get; set; }
    }
}
