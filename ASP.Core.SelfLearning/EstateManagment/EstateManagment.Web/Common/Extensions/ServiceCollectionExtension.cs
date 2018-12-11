using EstateManagment.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Reflection;

namespace EstateManagment.Web.Common.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDomainService(this IServiceCollection service)
        {
            Assembly
                .GetAssembly(typeof(IService))
                .GetTypes()
                .Where(t => t.IsClass && t.GetInterfaces()
                    .Any(i => i.Name == $"I{t.Name}"))
                .Select(t => new
                {
                    Interface = t.GetInterface($"I{t.Name}"),
                    Implementation = t
                })
                .ToList()
                .ForEach(s => service.AddScoped(s.Interface, s.Implementation));

            return service;
        }
    }
}
