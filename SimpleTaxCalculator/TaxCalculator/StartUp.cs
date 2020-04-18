using Microsoft.Extensions.DependencyInjection;
using System;

namespace TaxCalculator
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var serviceCollection = CreateCollection();
            var serviceProvider = serviceCollection.BuildServiceProvider();

            var engine = serviceProvider.GetService<IEngine>();
            engine.Run();
        }

        private static IServiceCollection CreateCollection()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddSingleton<IEngine, Engine>();

            return serviceCollection;
        }
    }
}
