namespace BookShop.Api.Infrastructure.Extensions
{
    using BookShop.Services;
    using Microsoft.Extensions.DependencyInjection;
    using System.Linq;
    using System.Reflection;

    public static class ServiceCollectionsExtensions
    {
        public static IServiceCollection AddDomainService(this IServiceCollection service)
        {
            Assembly
                .GetAssembly(typeof(IService))
                .GetTypes()
                .Where(t => t.IsClass && t.GetInterfaces().Any(i => i.Name == $"I{t.Name}"))
                .Select(t => new
                {
                    Interface = t.GetInterface($"I{t.Name}"),
                    Implementation = t
                })
                .ToList()
                .ForEach(s => service.AddTransient(s.Interface, s.Implementation));

            return service;
        }
    }
}
