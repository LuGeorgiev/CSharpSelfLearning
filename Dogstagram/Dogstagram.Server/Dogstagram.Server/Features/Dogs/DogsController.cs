using Dogstagram.Server.Features.Dogs.Models;
using Dogstagram.Server.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

using static Dogstagram.Server.Infrastructure.WebConstants;

namespace Dogstagram.Server.Features.Dogs
{
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
        [Route(Id)]
        public async Task<ActionResult> Update(string id, UpdateDogRequestModel model)
        {
            var userId = this.currentUser.GetId();
            var updated = await this.dogs.Update(id, model.Description, userId);

            if (updated.Failure)
            {
                return this.BadRequest(updated.Error);
            }

            return this.Ok();
        }

        [HttpDelete]
        [Route(Id)]
        public async Task<ActionResult> Delete(string id)
        {
            var userId = this.currentUser.GetId();
            var result = await this.dogs.Delete(id, userId);

            if (result.Failure)
            {
                return this.BadRequest(result.Error);
            }

            return this.Ok();
        }
        
    }
}
