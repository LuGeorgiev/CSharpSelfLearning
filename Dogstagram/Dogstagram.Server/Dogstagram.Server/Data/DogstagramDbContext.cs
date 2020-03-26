using Dogstagram.Server.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Dogstagram.Server.Data
{
    public class DogstagramDbContext : IdentityDbContext<User>
    {
        public DogstagramDbContext(DbContextOptions<DogstagramDbContext> options)
            : base(options)
        {
        }
    }
}
