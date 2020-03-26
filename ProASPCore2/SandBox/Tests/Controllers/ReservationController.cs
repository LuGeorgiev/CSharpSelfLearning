using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tests.Models;

namespace Tests.Controllers
{
    [Route("api/[controller]")]
    public class ReservationController : Controller
    {
        private readonly IRepository repo;

        public ReservationController(IRepository repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public IEnumerable<Reservation> Get()
            => this.repo.Reservations;

        [HttpGet("{id}")]
        public Reservation Get(int id)
            => this.repo[id];

        [HttpPost]
        [Consumes("application/json")]
        public Reservation Post([FromBody]Reservation res)
            => this.repo.AddReservation(new Reservation { ClientName = res.ClientName, Location = res.Location });


        [HttpPut]
        public Reservation Put([FromBody] Reservation res)
            => this.repo.UpdateReservation(res);

        [HttpPatch("{id}")]
        public StatusCodeResult Patch(int id, [FromBody] JsonPatchDocument<Reservation> patch)
        {
            var res = Get(id);
            if (res == null)
            {
                return NotFound();
            }

            patch.ApplyTo(res);

            return Ok();
        }

        [HttpDelete]
        public void Delete(int id)
            => this.repo.DeleteReservation(id);

    }
}
