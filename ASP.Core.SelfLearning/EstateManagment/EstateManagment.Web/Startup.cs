﻿using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EstateManagment.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using EstateManagment.Data.Models;
using Microsoft.AspNetCore.Identity.UI.Services;
using EstateManagment.Web.Areas.Identity.Services;
using EstateManagment.Web.Common.Extensions;
using AutoMapper;

namespace EstateManagment.Web
{
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<EstateManagmentContext>(options =>
                options
                .UseLazyLoadingProxies()
                .UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<User, IdentityRole>()
                //.AddDefaultUI()
                .AddEntityFrameworkStores<EstateManagmentContext>()
                .AddDefaultTokenProviders();

           

            services.AddAuthentication()
                .AddGoogle(options =>
                {
                    options.ClientId = this.Configuration.GetSection("ExternalAuthentication:Google:ClientId").Value;
                    options.ClientSecret = this.Configuration.GetSection("ExternalAuthentication:Google:ClientSecret").Value;
                });


            services.Configure<IdentityOptions>(options=>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 4;
                options.Password.RequiredUniqueChars = 1;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;

                options.Lockout.MaxFailedAccessAttempts = 4;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(20);

                options.SignIn.RequireConfirmedEmail = true;
            });           

            services.AddDomainService();

            services.AddSingleton<IEmailSender, SendGridEmailSender>();
            services.Configure<SendGridOptions>(this.Configuration.GetSection("SendGridSettings"));
            services.AddAutoMapper();

            services
                .AddMvc(options=> 
                {
                    options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddRazorPagesOptions(options =>
                {
                    options.AllowAreas = true;
                    options.Conventions.AuthorizeAreaFolder("Identity", "/Account/Manage");
                    options.Conventions.AuthorizeAreaPage("Identity", "/Account/Logout");
                });
        }


        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {            

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();

            app.SeedDatabase();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "areas",
                    template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                   name: "default",
                   template: "{controller=Home}/{action=Index}/{id?}");
            });           

        }
    }
}
