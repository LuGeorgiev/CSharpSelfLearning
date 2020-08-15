using Dogstagram.Server.Data.Models;
using Dogstagram.Server.Features.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace Dogstagram.Server.Features.Identity
{
    public class IdentityController : ApiController
    {
        private readonly UserManager<User> user;
        private readonly AppSettings appSettings;
        private readonly IIdentityService identity;

        public IdentityController(UserManager<User> userManger, IOptions<AppSettings> appSettings, IIdentityService identityService)
        { 
            this.user = userManger;
            this.appSettings = appSettings.Value;
            this.identity = identityService;
        } 

        [HttpPost]
        [Route(nameof(Register))]
        public async Task<ActionResult> Register(RegisterUserModel model)
        {
            var user = new User
            {
                Email = model.Email,
                UserName = model.Username
            };
            var result = await this.user.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                return this.Ok();
            }

            return BadRequest(result.Errors);
        }

        [HttpPost]
        [Route(nameof(Login))]
        public async Task<ActionResult<object>>Login(LoginRequestModel model)
        {
            var user = await this.user.FindByNameAsync(model.Username);
            if (user == null)
            {
                return Unauthorized();
            }
            
            var passwordValid = await this.user.CheckPasswordAsync(user, model.Password);
            if (! passwordValid)
            {
                return Unauthorized();
            }

            var encryptedToken = this.identity.GenerateJwtToken(user.UserName, user.Id, appSettings.Secret);

            return new LoginResponseModel
            {
                Token = encryptedToken 
            };
        }
    }
}
