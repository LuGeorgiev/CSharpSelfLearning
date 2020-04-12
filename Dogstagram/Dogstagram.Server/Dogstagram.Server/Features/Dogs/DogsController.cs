using Dogstagram.Server.Infrastructure.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Dogstagram.Server.Features.Dogs
{
    public class DogsController :ApiController
    {
        private readonly IDogService dogService;

        public DogsController(IDogService dogService)
        {
            this.dogService = dogService;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Create(CreateDogRequestModel model)
        {
            var userId = this.User.GetId();

            var dogId = await this.dogService.CreateDog(userId, model.ImageUrl, model.Description);

            return Created(nameof(this.Create), dogId);
        }
    }
}
