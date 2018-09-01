

namespace CamaraBazar.Web
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using CamaraBazar.Data;
    using CamaraBazar.Data.Models;
    using CamaraBazar.Web.Infrastricture.Extensions;
    using CamaraBazar.Services;
    using CamaraBazar.Services.Implementation;
    using CamaraBazar.Web.Infrastricture.Filters;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<CameraBazarDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services
                .AddIdentity<User, IdentityRole>(options=> 
                    {
                        options.Password.RequireDigit = false;
                        options.Password.RequireLowercase = false;
                        options.Password.RequireNonAlphanumeric = false;
                        options.Password.RequireUppercase = false;
                    })
                .AddEntityFrameworkStores<CameraBazarDbContext>()
                .AddDefaultTokenProviders();

            //services.AddTransient<IEmailSender, EmailSender>();
            services.AddTransient<ICameraService, CameraService>();

            //To add teh filter golobally not only to Home controller:
            services.AddMvc( options=> 
            {
                options.Filters.Add<LogAttribute>();
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDatabaseMigration();

            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //        name: "default",
            //        template: "{controller=Home}/{action=Index}/{id?}");
            //});
            app.UseMvcWithDefaultRoute();
        }
    }
}
