namespace CamaraBazar.Web.Infrastricture.Extensions
{
    using CamaraBazar.Data;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseDatabaseMigration(this IApplicationBuilder app)
        {
            using (var serviceSope =app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                serviceSope.ServiceProvider.GetService<CameraBazarDbContext>().Database.Migrate();                
            }
            return app;
        }
    }
}
