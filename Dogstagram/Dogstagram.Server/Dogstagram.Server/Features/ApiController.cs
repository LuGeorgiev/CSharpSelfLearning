using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dogstagram.Server.Features
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    abstract  public class ApiController :ControllerBase
    {
    }
}
