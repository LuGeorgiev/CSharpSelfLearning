using Microsoft.AspNetCore.Mvc;
using Tests.Models;

namespace Tests.Controllers
{
    [Route("api/[controller]")]
    public class ContentController : Controller
    {
        [HttpGet("string")]
        public string GetString() => "this is string respones";

        [HttpGet("object/{format?}")]
        [FormatFilter]
        //[Produces("application/json","application/xml")]
        public Reservation GetObject() => new Reservation {ClientName = "test", Location="Mars" };

    }
}
