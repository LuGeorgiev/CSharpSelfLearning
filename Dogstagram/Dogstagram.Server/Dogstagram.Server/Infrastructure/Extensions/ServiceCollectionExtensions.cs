
using Dogstagram.Server.Data;
using Dogstagram.Server.Data.Models;
using Dogstagram.Server.Features.Dogs;
using Dogstagram.Server.Features.Identity;
using Dogstagram.Server.Infrastructure.Filters;
using Dogstagram.Server.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace Dogstagram.Server.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
            => services.AddDbContext<DogstagramDbContext>(options =>
                        options.UseSqlServer(configuration.GetDefaultConnectionString()));


        public static IServiceCollection AddIdentity(this IServiceCollection services)
        {
            services
                .AddIdentity<User, IdentityRole>(opt =>
                {
                    opt.Password.RequireDigit = false;
                    opt.Password.RequiredLength = 3;
                    opt.Password.RequireNonAlphanumeric = false;
                    opt.Password.RequireUppercase = false;
                    opt.Password.RequireLowercase = false;
                })
                .AddEntityFrameworkStores<DogstagramDbContext>();

            return services;
        }

        public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, AppSettings appSettings)
        {    
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);

            services.AddAuthentication(x =>
              {
                  x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                  x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
              })
            .AddJwtBearer(x =>
                            {
                                x.RequireHttpsMetadata = false;
                                x.SaveToken = true;
                                x.TokenValidationParameters = new TokenValidationParameters
                                {
                                    ValidateIssuerSigningKey = true,
                                    IssuerSigningKey = new SymmetricSecurityKey(key),
                                    ValidateIssuer = false,
                                    ValidateAudience = false
                                };
                            });

            return services;
        }

        public static IServiceCollection AddApplicationServices(this IServiceCollection sercices)
            => sercices
                    .AddTransient<IIdentityService, IdentityService>()
                    .AddScoped<ICurrentUserService, CurrentUserService>()
                    .AddTransient<IDogService, DogService>();

        public static IServiceCollection AddSwagger(this IServiceCollection services)
            =>  services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My Dogstagram", Version = "v1" });
            });

        public static void AddApiControllers(this IServiceCollection services)
            => services.AddControllers(opt => opt.Filters.Add<ModelOrNotFoundActionFilter>());
    }
}
