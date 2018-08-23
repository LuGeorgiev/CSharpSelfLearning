
namespace CarDealer.Services
{
    using Models.Customers;
    using System.Collections.Generic;

    public interface ICustomerService
    {
        IEnumerable<CustomerModel> Ordered(OrderDirection order);

        SalesByCustomer TotalSales(int id);
    }
}
