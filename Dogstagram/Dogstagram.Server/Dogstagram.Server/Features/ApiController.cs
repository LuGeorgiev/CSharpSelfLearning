using Microsoft.AspNetCore.Mvc;

namespace Dogstagram.Server.Features
{
    [ApiController]
    [Route("[controller]")]
    abstract  public class ApiController :ControllerBase
    {
    }
}
