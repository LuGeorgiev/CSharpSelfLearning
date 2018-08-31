

namespace CarDealer.Web
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using CarDealer.Data.Models;    
    using CarDealer.Data;
    using Services;
    using Services.Implementations;
    using Infrastructure.Extensions;
    using Microsoft.AspNetCore.Mvc;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<CarDealerDbContext>(options =>
                options
                .UseLazyLoadingProxies()
                .UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services
                .AddIdentity<User, IdentityRole>(options=> 
                {
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                })
                .AddEntityFrameworkStores<CarDealerDbContext>()
                .AddDefaultTokenProviders();

            //services.AddTransient<ICustomerService, CustomerService>();
            //services.AddTransient<ICarService, CarService>();
            //services.AddTransient<ISupplierService, SupplierService>();
            //services.AddTransient<ISaleService, SaleService>();
            services.AddDomainServices(); // this way services will be registered automatically

            services.AddMvc(options =>
            {
                options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
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
            //            //Following routing is currently as attribute
            //    //routes.MapRoute(
            //    //    name: "customers",
            //    //    template: "customers/all/{order}",
            //    //    defaults: new { controller="Customers",action="All"});

            //    routes.MapRoute(
            //        name: "default",
            //        template: "{controller=Home}/{action=Index}/{id?}");
            //});
            app.UseMvcWithDefaultRoute(); // that substitutes the upper
        }
    }
}
