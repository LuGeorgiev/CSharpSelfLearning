using Dogstagram.Server.Data;
using Dogstagram.Server.Data.Models;
using Dogstagram.Server.Infrastructure.Extensions;
using Dogstagram.Server.Models.Dogs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Dogstagram.Server.Controllers
{    
    public class DogsController :ApiController
    {
        private readonly DogstagramDbContext db;

        public DogsController(DogstagramDbContext db)
        {
            this.db = db;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Create(CreateDogRequestModel model)
        {
            var userId = this.User.GetId();
            var dog = new Dog 
            {
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                UserId = userId
            };

            db.Dogs.Add(dog);
            await db.SaveChangesAsync();

            return Created(nameof(this.Create), dog.Id);
        }
    }
}
