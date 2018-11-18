using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EstateManagment.Web.Areas.Admin.Controllers
{
    
    [Area("Admin")]
    [Authorize(Roles = WebConstants.AdminRole)]
    public abstract class AdminController : Controller
    {       
    }
}