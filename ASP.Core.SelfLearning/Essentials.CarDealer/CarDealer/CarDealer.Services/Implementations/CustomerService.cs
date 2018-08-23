
namespace CarDealer.Services.Implementations
{
    using Models.Customers;
    using Data;
    using System.Collections.Generic;
    using System.Linq;
    using System;
    using Microsoft.EntityFrameworkCore;

    public class CustomerService : ICustomerService
    {
        private readonly CarDealerDbContext db;

        public CustomerService(CarDealerDbContext   db)
        {
            this.db = db;
        }

        public IEnumerable<CustomerModel> Ordered(OrderDirection order)
        {
            var customersQuery = this.db.Customers.AsQueryable();
            switch (order)
            {
                case OrderDirection.Ascending:
                    customersQuery = customersQuery
                        .OrderBy(c => c.BirthDate)
                        .ThenBy(c=>c.Name);
                    break;
                case OrderDirection.Descending:
                    customersQuery = customersQuery
                        .OrderByDescending(c => c.BirthDate)
                        .ThenBy(c=>c.Name);
                    break;
                default:
                    throw new InvalidOperationException($"Invalid ordert direction: {order}.");
            }

            return customersQuery
                .Select(c => new CustomerModel
                {
                    Name=c.Name,
                    BirthDate=c.BirthDate,
                    IsYoungDriver=c.IsYoungDriver
                })
                .ToList();
        }

        public SalesByCustomer TotalSales(int id)
        {
            var customer = db.Customers
                .Include(c=>c.Sales)
                .ThenInclude(c=>c.Car)
                .ThenInclude(c=>c.Parts) 
                .ThenInclude(c=>c.Part)
                .ThenInclude(c=>c.Cars)
                .FirstOrDefault(c => c.Id == id);

            if (customer ==null)
            {
                throw new ArgumentException($"Customer with Id: {id} was not found!");
            }

            return new SalesByCustomer
            {
                Name =customer.Name,
                BoughtCars = customer.Sales.Count,
                TotalSpentMoney = customer.Sales.Sum(c=>c.Car.Parts.Sum(p=>p.Part.Price)* (decimal)(1-c.Discount))
            };            
        }
    }
}
