using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cities.Components
{
    public class TimeViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
            => View(DateTime.Now);
    }
}
