using Dogstagram.Server.Features.Follows.Models;
using Dogstagram.Server.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Dogstagram.Server.Features.Follows
{
    public class FollowsController : ApiController
    {
        private readonly ICurrentUserService currentUser;
        private readonly IFollowService follows;

        public FollowsController(ICurrentUserService currentUser, IFollowService follows)
        {
            this.currentUser = currentUser;
            this.follows = follows;
        }

        [HttpPost]
        public async Task<ActionResult> Follow(FollowRequestModel model)
        {
            var result = await this.follows.Follow(model.UserId, this.currentUser.GetId());
            if (result.Failure)
            {
                return BadRequest(result.Error);
            }

            return Ok();
        }
    }
}
