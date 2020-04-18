using Microsoft.Extensions.DependencyInjection;
using TaxCalculator.BusinessLogic;
using TaxCalculator.Extensions;
using TaxCalculator.Services.InputOutput;
using TaxCalculator.Services.InputOutput.Implementation;

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

            serviceCollection.AddTransient<IWriter, ConsoleWriter>();
            serviceCollection.AddTransient<IReader, ConsoleReader>();
            serviceCollection.AddTransient<ISalaryCalculator, SalaryCalculator>();

            serviceCollection.AddServicesByConvention();

            return serviceCollection;
        }
    }
}
