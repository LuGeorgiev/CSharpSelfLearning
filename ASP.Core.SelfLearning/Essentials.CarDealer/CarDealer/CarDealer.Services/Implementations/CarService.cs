
namespace CarDealer.Services.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using CarDealer.Data;
    using Models.Parts;
    using Models.Cars;
    using CarDealer.Data.Models;

    public class CarService : ICarService
    {
        private readonly CarDealerDbContext db;
        public CarService(CarDealerDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<CarModel> ByMake(string make)
             => this.db
                .Cars
                .Where(c => c.Make.ToLower() == make.ToLower())
                .OrderBy(c => c.Model)
                .ThenBy(c => c.TravelledDistance)
                .Select(c=> new CarModel
                {
                    Make=c.Make,
                    Model=c.Model,
                    TravelledDistance=c.TravelledDistance
                })
                .ToList();

        public void Create(string make, string model, long travelledDistance)
        {
            var car = new Car
            {
                Make = make,
                Model = model,
                TravelledDistance = travelledDistance
            };

            this.db.Cars.Add(car);
            this.db.SaveChanges();
        }

        public IEnumerable<CarWithPartsModel> WithParts()
            => this.db
            .Cars
            .OrderByDescending(c=>c.Id)
            .Select(c => new CarWithPartsModel
            {
                Make=c.Make,
                Model=c.Model,
                TravelledDistance=c.TravelledDistance,
                Parts = c.Parts
                .Select(p=> new PartModel
                {
                    Name=p.Part.Name,
                    Price=p.Part.Price
                })
                .ToList()
            })
            .ToList();


    }
}
