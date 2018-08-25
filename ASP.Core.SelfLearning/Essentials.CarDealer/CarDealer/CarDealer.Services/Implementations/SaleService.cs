
namespace CarDealer.Services.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Data;
    using Models.Cars;
    using Models.Sales;

    public class SaleService : ISaleService
    {
        private readonly CarDealerDbContext db;
        public SaleService(CarDealerDbContext db)
        {
            this.db = db;
        }

        public SaleDetailsModel ById(int id)
            => this.db.Sales
            .Where(s => s.Id == id)
            .Select(s => new SaleDetailsModel
            {
                Id=s.Id,
                CustomerName = s.Customer.Name,
                IsYoungDriver = s.Customer.IsYoungDriver,
                Discount = s.Discount,
                Price = s.Car.Parts.Sum(p => p.Part.Price),
                Car = new CarModel
                {                    
                    Make=s.Car.Make,
                    Model=s.Car.Model,
                    TravelledDistance = s.Car.TravelledDistance
                }
            })
            .FirstOrDefault();

        public IEnumerable<SaleListModel> Discounted()
        {

            throw new NotImplementedException();
           //=> db.Sales
           //     .Where(s=>s.Discount>0)
           //     .Select(s => new SaleListModel
           //     {
           //         Make = s.Car.Make,
           //         Model = s.Car.Model,
           //         TravelledDistance = s.Car.TravelledDistance,
           //         CustomerName = s.Customer.Name,
           //         Discount = s.Discount,
           //         Price = s.Car.Parts.Sum(p => p.Part.Price)
           //     })
           //     .ToList();
        }

        public IEnumerable<SaleListModel> DiscountedByPercent(double percent)
        {
            throw new NotImplementedException();
        }
         //=> db.Sales
         //       .Where(s => s.Discount == percent)
         //       .Select(s => new SaleListModel
         //       {
         //           Make = s.Car.Make,
         //           Model = s.Car.Model,
         //           TravelledDistance = s.Car.TravelledDistance,
         //           CustomerName = s.Customer.Name,
         //           Discount = s.Discount,
         //           Price = s.Car.Parts.Sum(p => p.Part.Price)
         //       })
         //       .ToList();

        public IEnumerable<SaleListModel> All()
            => db
                .Sales
                .OrderByDescending(s=>s.Id)
                .Select(s => new SaleListModel
                {          
                    Id=s.Id,
                    CustomerName=s.Customer.Name,
                    IsYoungDriver=s.Customer.IsYoungDriver,
                    Discount=s.Discount,
                    Price=s.Car.Parts.Sum(p=>p.Part.Price)                 
                })
                .ToList();
    }
}
