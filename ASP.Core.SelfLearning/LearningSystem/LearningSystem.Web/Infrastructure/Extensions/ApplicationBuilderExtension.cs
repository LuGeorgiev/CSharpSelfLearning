
namespace LearningSystem.Web.Infrastructure.Extensions
{
    using Data;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    public static class ApplicationBuilderExtension
    {
        public static IApplicationBuilder UseDatabaseMigration(this IApplicationBuilder app)
        {
            using (var serviceSope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                serviceSope.ServiceProvider.GetService<LearningSystemDbContext>().Database.Migrate();
            }

            return app;
        }
    }
}
