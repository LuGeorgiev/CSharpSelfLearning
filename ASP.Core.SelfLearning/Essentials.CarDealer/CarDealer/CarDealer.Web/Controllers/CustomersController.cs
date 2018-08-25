
namespace CarDealer.Web.Controllers
{
    using Infrastructure.Extensions;
    using Microsoft.AspNetCore.Mvc;
    using Models.Customers;
    using Services;
    using Services.Models.Customers;

    [Route("customers")]
    public class CustomersController : Controller
    {
        private readonly ICustomerService customers;
        public CustomersController(ICustomerService customers)
        {
            this.customers = customers;
        }

        [Route(nameof(Create))]
        public IActionResult Create() => View();

        [HttpPost]
        [Route(nameof(Create))]
        public IActionResult Create(CustomerFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            this.customers.Create(
                model.Name,
                model.BirthDate,
                model.IsYoungDriver);

            return RedirectToAction(nameof(All),new { order = OrderDirection.Ascending.ToString()});
        }

        [Route(nameof(Edit) + "/{id}")]
        public IActionResult Edit(int id)
        {
            var customer = this.customers.ById(id);
            if (customer==null)
            {
                return NotFound();
            }

            return View(new CustomerFormModel
            {
                Name=customer.Name,
                BirthDate=customer.BirthDate,
                IsYoungDriver=customer.IsYoungDriver
            });
        }

        [HttpPost]
        [Route(nameof(Edit) + "/{id}")]
        public IActionResult Edit(int id, CustomerFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var customerExists = this.customers.Exists(id);
            if (!customerExists)
            {
                return NotFound();
            }

            this.customers.Edit(
                model.Id,
                model.Name,
                model.BirthDate,
                model.IsYoungDriver);

            return RedirectToAction(nameof(All), new { order = OrderDirection.Ascending.ToString() });
        }

        [Route("all/{order}")]
        public IActionResult All(string order)
        {
            var orderDirection = order.ToLower() == "descending"
                ? OrderDirection.Descending
                : OrderDirection.Ascending;

            var customers = this.customers.Ordered(orderDirection);

            return View(new AllCustomersModel
            {
                Customers = customers,
                OrderDirection=orderDirection
            });
        }

        [Route("{id}")]
        public IActionResult Id(int id)
            =>  this.ViewOrNotFound(this.customers.TotalSalesById(id));      
           

                  
    }
}
