namespace CarDealer.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Models.Cars;
    using Services;   

    [Route("cars")]
    public class CarsController : Controller
    {
        private readonly ICarService cars;
        public CarsController(ICarService cars)
        {
            this.cars = cars;
        }

        [Route(nameof(Create))]
        public IActionResult Create() => View();

        [HttpPost]
        [Route(nameof(Create))]
        public IActionResult Create(CarFormModel carModel)
        {
            if (!ModelState.IsValid)
            {
                return View(carModel);
            }

            this.cars.Create(
                carModel.Make,
                carModel.Model,
                carModel.TravelledDistance);

            return RedirectToAction(nameof(Parts));
        }

        [Route("{make}",Order =2)]
        public IActionResult ByMake(string make)
        {
            var cars = this.cars.ByMake(make);

            return View(new CarsByMakeModel
            {
                Make = make,
                Cars = cars
            });
        }

        [Route("parts",Order =1)]
        public IActionResult Parts()
            => View(this.cars.WithParts());

        
    }
}
