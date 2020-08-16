using Dogstagram.Server.Features.Follows;
using Dogstagram.Server.Features.Profiles.Models;
using Dogstagram.Server.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

using static Dogstagram.Server.Infrastructure.WebConstants;

namespace Dogstagram.Server.Features.Profiles
{
    public class ProfilesController : ApiController
    {
        private readonly IProfileService profiles;
        private readonly ICurrentUserService currentUser;
        private readonly IFollowService follows;

        public ProfilesController(IProfileService profiles, ICurrentUserService currentUser, IFollowService follows)
        {
            this.profiles = profiles;
            this.currentUser = currentUser;
            this.follows = follows;
        }

        [HttpGet]
        public async Task<ProfileServiceModel> Mine()
            => await this.profiles.ByUser(this.currentUser.GetId(), allInformation :true);

        [HttpGet]
        [Route(Id)]
        public async Task<ProfileServiceModel> Details(string id)
        {
            var includeAllInformation = await this.follows.IsFollower(id, currentUser.GetId());

            if (!includeAllInformation)
            {
                includeAllInformation = await this.profiles.IsPublic(id);
            }
            await this.profiles.ByUser(id, includeAllInformation);

            return null;
        }

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
