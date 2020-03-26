using Dogstagram.Server.Data.Models;
using Dogstagram.Server.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Dogstagram.Server.Controllers
{
    public class IdentityController : ApiController
    {
        private readonly UserManager<User> userManger;
        private readonly AppSettings appSettings;

        public IdentityController(UserManager<User> userManger, IOptions<AppSettings> appSettings)
        { 
            this.userManger = userManger;
            this.appSettings = appSettings.Value;
        } 

        [Route(nameof(Register))]
        public async Task<ActionResult> Register(RegisterUserRequestModel model)
        {
            var user = new User
            {
                Email = model.Email,
                UserName = model.Username
            };
            var result = await this.userManger.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                return this.Ok();
            }

            return BadRequest(result.Errors);
        }

        [Route(nameof(Ligin))]
        public async Task<ActionResult<object>>Ligin(LoginRequestModel model)
        {
            var user = await this.userManger.FindByNameAsync(model.Username);
            if (user == null)
            {
                return Unauthorized();
            }
            
            var passwordValid = await this.userManger.CheckPasswordAsync(user, model.Password);
            if (! passwordValid)
            {
                return Unauthorized();
            }



            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(this.appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, model.Username)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var encryptedToken = tokenHandler.WriteToken(token);

            return new { Token = encryptedToken };
        }
    }
}
