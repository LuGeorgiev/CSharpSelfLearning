using Dogstagram.Server.Features.Dogs.Models;
using Dogstagram.Server.Infrastructure.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dogstagram.Server.Features.Dogs
{
    [Authorize]
    public class DogsController : ApiController
    {
        private readonly IDogService dogService;

        public DogsController(IDogService dogService)
        {
            this.dogService = dogService;
        }


        [HttpGet]
        public async Task<IEnumerable<DogListingServiceModel>> Mine()
        {
            var userId = this.User.GetId();
            return await this.dogService.ByUser(userId);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<DogDetailsServiceModel>> Details(string id)
        {
            var dog = await this.dogService.DetailsByDogId(id);

            //if (dog == null) - instead of this code or NoTFound Extension filter was added
            //{
            //    return this.NotFound();
            //}

            return dog; //.OrNotFound();
        }


        [HttpPost]
        public async Task<ActionResult> Create(CreateDogRequestModel model)
        {
            var userId = this.User.GetId();
            var dogId = await this.dogService.CreateDog(userId, model.ImageUrl, model.Description);

            return Created(nameof(this.Create), dogId);
        }

        [HttpPut]
        public async Task<ActionResult> Update(UpdateDogRequestModel model)
        {
            var userId = this.User.GetId();
            var updated = await this.dogService.Update(model.Id, model.Description, userId);

            if (! updated)
            {
                return this.BadRequest();
            }

            return this.Ok();
        }
        
    }
}
