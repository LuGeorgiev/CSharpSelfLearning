
namespace IdentityDemo.Infrastructure.Extensions
{
    using IdentityDemo.Data;
    using IdentityDemo.Models;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Threading.Tasks;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseDatabaseMigration(this IApplicationBuilder app)
        {
            using (var serviceScope =app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                serviceScope.ServiceProvider.GetService<ApplicationDbContext>().Database.Migrate();

                var userManager = serviceScope.ServiceProvider.GetService<UserManager<User>>();
                var roleManager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>();

                Task
                    .Run(async () => 
                    {
                        var adminName = GlobalConstants.AdministatorRole;

                        var roleExist = await roleManager.RoleExistsAsync(adminName);

                        if (!roleExist)
                        {
                            await roleManager.CreateAsync(new IdentityRole
                            {
                                Name=adminName
                            });
                        }

                        var adminEmail = "admin@mySite.com";

                        var adminUser = await userManager.FindByNameAsync(adminEmail);
                        if (adminUser == null)
                        {
                            adminUser = new User
                            {
                                Email = adminEmail,
                                UserName = adminEmail,
                                //SecurityStamp = Guid.NewGuid().ToString()
                            };

                            await userManager.CreateAsync(adminUser, "Admin12");

                            await userManager.AddToRoleAsync(adminUser, adminName);
                        }
                    })
                        .Wait();
            }

            return app;
        }
    }
}
