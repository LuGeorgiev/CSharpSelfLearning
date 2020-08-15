using Dogstagram.Server.Features.Dogs.Models;
using Dogstagram.Server.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

using static Dogstagram.Server.Infrastructure.WebConstants;

namespace Dogstagram.Server.Features.Dogs
{
    [Authorize]
    public class DogsController : ApiController
    {
        private readonly IDogService dogs;
        private readonly ICurrentUserService currentUser;

        public DogsController(IDogService dogService, ICurrentUserService currentUserService)
        {
            this.dogs = dogService;
            this.currentUser = currentUserService;
        }


        [HttpGet]
        public async Task<IEnumerable<DogListingServiceModel>> Mine()
        {
            var userId = this.currentUser.GetId();
            return await this.dogs.ByUser(userId);
        }

        [HttpGet]
        [Route(Id)]
        public async Task<ActionResult<DogDetailsServiceModel>> Details(string id)
        {
            var dog = await this.dogs.DetailsByDogId(id);

            //if (dog == null) - instead of this code or NoTFound Extension filter was added
            //{
            //    return this.NotFound();
            //}

            return dog; //.OrNotFound();
        }


        [HttpPost]
        public async Task<ActionResult> Create(CreateDogRequestModel model)
        {
            var userId = this.currentUser.GetId();
            var dogId = await this.dogs.CreateDog(userId, model.ImageUrl, model.Description);

            return Created(nameof(this.Create), dogId);
        }

        [HttpPut]
        public async Task<ActionResult> Update(UpdateDogRequestModel model)
        {
            var userId = this.currentUser.GetId();
            var updated = await this.dogs.Update(model.Id, model.Description, userId);

            if (! updated)
            {
                return this.BadRequest();
            }

            return this.Ok();
        }

        [HttpDelete]
        [Route(Id)]
        public async Task<ActionResult> Delete(string id)
        {
            var userId = this.currentUser.GetId();
            var isDeleted = await this.dogs.Delete(id, userId);

            if (! isDeleted)
            {
                return this.BadRequest();
            }

            return this.Ok();
        }
        
    }
}
