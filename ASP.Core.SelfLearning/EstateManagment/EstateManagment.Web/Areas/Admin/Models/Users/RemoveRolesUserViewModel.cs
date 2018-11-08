﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstateManagment.Web.Areas.Admin.Models.Users
{
    public class RemoveRolesUserViewModel
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public IEnumerable<SelectListItem> Roles { get; set; }
    }
}
