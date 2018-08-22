namespace CarDealer.Services
{
    using CarDealer.Services.Models.Cars;
    using System.Collections.Generic;


    public interface ICarService
    {
        IEnumerable<CarModel> ByMake(string make);

        IEnumerable<CarWithPartsModel> WithParts();
    }
}
