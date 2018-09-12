namespace BookShop.Api
{
    using AutoMapper;
    using Infrastructure.Extensions;
    using Data;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddDbContext<BookShopDbContext>(opt=>opt
                    .UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services
                .AddDomainService();

            services
                .AddAutoMapper();

            services
                .AddRouting(routing => routing.LowercaseUrls = true);

            services
                .AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDatabaseMigration();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
