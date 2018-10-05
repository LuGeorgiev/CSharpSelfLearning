using System;
using System.Collections.Generic;
using System.Text;
using EstateManagment.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EstateManagment.Data
{
    public class EsteteManagmentContext : IdentityDbContext<User>
    {
        public EsteteManagmentContext(DbContextOptions<EsteteManagmentContext> options)
            : base(options)
        {
        }
    }
}
