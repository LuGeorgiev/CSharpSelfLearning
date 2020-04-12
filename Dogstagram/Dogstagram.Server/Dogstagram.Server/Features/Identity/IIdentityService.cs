using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dogstagram.Server.Features.Identity
{
    public interface IIdentityService
    {
        string GenerateJwtToken(string userName, string userId, string secret);
    }
}
