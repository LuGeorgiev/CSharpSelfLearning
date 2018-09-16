﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ShoppingCartDemo.Data.Models;

namespace ShoppingCartDemo.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
