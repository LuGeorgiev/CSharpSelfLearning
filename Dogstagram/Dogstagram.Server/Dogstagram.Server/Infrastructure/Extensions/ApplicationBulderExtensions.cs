using Dogstagram.Server.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Dogstagram.Server.Infrastructure.Extensions
{
    public static class ApplicationBulderExtensions
    {
        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using var services = app.ApplicationServices.CreateScope();
            var dbContext = services.ServiceProvider.GetService<DogstagramDbContext>();

            dbContext.Database.Migrate();
        }

        public static IApplicationBuilder UseSwaggerUi(this IApplicationBuilder app)
            => app.UseSwagger()
                .UseSwaggerUI(opt =>
                {
                    opt.SwaggerEndpoint("/swagger/v1/swagger.json", "My Dogstagram v1");
                    opt.RoutePrefix = string.Empty;
                });
    }
}
