
namespace CarDealer.Services.Implementations
{
    using Models.Customers;
    using Data;
    using System.Collections.Generic;
    using System.Linq;
    using System;
    using Microsoft.EntityFrameworkCore;
    using CarDealer.Services.Models.Sales;
    using CarDealer.Data.Models;

    public class CustomerService : ICustomerService
    {
        private readonly CarDealerDbContext db;

        public CustomerService(CarDealerDbContext   db)
        {
            this.db = db;
        }

        public CustomerModel ById(int id)
        {
            var customer = db.Customers
                .Where(c => c.Id == id)
                .Select(c=>new CustomerModel
                {
                    Id=c.Id,
                    Name=c.Name,
                    BirthDate=c.BirthDate,
                    IsYoungDriver=c.IsYoungDriver                    
                })
                .FirstOrDefault();

            return customer;
        }

        public void Create(string name, DateTime birthDate, bool isYoungDriver)
        {
            var customer = new Customer
            {
                Name=name,
                BirthDate=birthDate,
                IsYoungDriver=isYoungDriver
            };

            this.db.Customers.Add(customer);
            this.db.SaveChanges();
        }

        public void Edit(int id,string name, DateTime birthDate, bool isYoungDriver)
        {
            var exisingCustomers = this.db.Customers.Find(id);

            if (exisingCustomers==null)
            {
                return;
            }

            exisingCustomers.Name = name;
            exisingCustomers.BirthDate = birthDate;
            exisingCustomers.IsYoungDriver = isYoungDriver;

            this.db.SaveChanges();
        }

        public bool Exists(int id)
            => this.db.Customers.Any(c => c.Id == id);

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
                    Id=c.Id,
                    Name=c.Name,
                    BirthDate=c.BirthDate,
                    IsYoungDriver=c.IsYoungDriver
                })
                .ToList();
        }

        public CustomerTotalSalesModel TotalSalesById(int id)
        {
            var customer = db.Customers
                .Where(c=>c.Id==id)
                .FirstOrDefault();

            if (customer ==null)
            {
                throw new ArgumentException($"Customer with Id: {id} was not found!");
            }

            return new CustomerTotalSalesModel
            {
                Name =customer.Name,                
                IsYoungDriver=customer.IsYoungDriver,
                BoughtCars = customer.Sales.Select(s=>new SaleModel
                {
                    Price=s.Car.Parts.Sum(p=>p.Part.Price),
                    Discount=s.Discount
                }).ToList()
            };            
        }
    }
}
