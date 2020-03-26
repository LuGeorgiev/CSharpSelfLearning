using Microsoft.AspNetCore.Mvc;

namespace Dogstagram.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    abstract  public class ApiController :ControllerBase
    {
    }
}
