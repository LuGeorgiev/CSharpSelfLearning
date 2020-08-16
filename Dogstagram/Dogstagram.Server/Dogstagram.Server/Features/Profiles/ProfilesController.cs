using Dogstagram.Server.Features.Profiles.Models;
using Dogstagram.Server.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Dogstagram.Server.Features.Profiles
{
    public class ProfilesController : ApiController
    {
        private readonly IProfileService profiles;
        private readonly ICurrentUserService currentUser;

        public ProfilesController(IProfileService profiles, ICurrentUserService currentUser)
        {
            this.profiles = profiles;
            this.currentUser = currentUser;
        }

        [HttpGet]
        public async Task<ActionResult<ProfileServiceModel>> Mine()
            => await this.profiles.ByUser(this.currentUser.GetId());

        [HttpPut]
        public async Task<ActionResult> Update(UpdateProfileRequestModel model)
        {
            var userId = this.currentUser.GetId();

            var updated = await this.profiles.Update(
                userId,
                model.Email,
                model.UserName,
                model.Name,
                model.MainPhotoUrl,
                model.WebSite,
                model.Biography,
                model.Gender,
                model.IsPrivate);

            if (updated.Failure)
            {
                return BadRequest(updated.Error);
            }

            return Ok();
        }
    }
}
