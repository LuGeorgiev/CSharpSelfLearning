
namespace CarDealer.Web.Controllers
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    using Services;
    using Infrastructure.Extensions;
    using Models.Sales;
    using Services.Models.Sales;

    [Route("sales")]
    public class SalesController: Controller
    {
        private readonly ISaleService sales;
        public SalesController(ISaleService sales)
        {
            this.sales = sales;
        }

        [Route("")]
        public IActionResult Sales()
            => View(this.sales.All());
        

        [Route("{id}")]
        public IActionResult Details(int id)
            => this.ViewOrNotFound(this.sales.ById(id));
   
    }
}
