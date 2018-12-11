using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EstateManagment.Web.Areas.Payments.Controllers
{
    [Area("Payments")]
    [Authorize(Roles = "Manager, Accountant")]
    public abstract class PaymentsBaseController : Controller
    {   
    }
}