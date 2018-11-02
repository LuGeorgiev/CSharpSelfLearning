using EstateManagment.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace EstateManagment.Web.Common.Extensions
{
    public static class ApplicationBuilderAuthExtensions
    {
        private static string DefaultAdminPass = "admin1";
        private static string DefaultAdminUsername = "adminAdmin";
        private static string DefaultAdminEmail = "admin1@admin.bg";

        private static IdentityRole[] roles =
        {
            new IdentityRole(WebConstants.AdminRole),
            new IdentityRole(WebConstants.ManagerRole),
            new IdentityRole(WebConstants.AccountantRole)
        };

        public static IApplicationBuilder SeedDatabase(this IApplicationBuilder app)
        {
            var serviceFactory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>();
            var scope = serviceFactory.CreateScope();

            using (scope)
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();

                Task.Run(async () =>
               {
                   foreach (var role in roles)
                   {
                       if (!await roleManager.RoleExistsAsync(role.Name))
                       {
                           var result = await roleManager.CreateAsync(role);
                       }
                   }

                   var adminUser = await userManager.FindByEmailAsync(DefaultAdminEmail);
                   if (adminUser == null)
                   {
                       adminUser = new User()
                       {
                           UserName = DefaultAdminUsername,
                           Email = DefaultAdminEmail,
                       };

                       var result = await userManager.CreateAsync(adminUser, DefaultAdminPass);
                       result = await userManager.AddToRoleAsync(adminUser, roles[0].Name);
                   }
               })
               .Wait();
            }
            return app;
        }
    }
}
