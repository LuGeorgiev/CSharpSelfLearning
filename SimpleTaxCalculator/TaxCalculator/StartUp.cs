using Microsoft.Extensions.DependencyInjection;
using TaxCalculator.BusinessLogic;
using TaxCalculator.Services.Infrastructure;
using TaxCalculator.Services.Infrastructure.Implementation;
using TaxCalculator.Services.InputOutput;
using TaxCalculator.Services.InputOutput.Implementation;
using TaxCalculator.Services.TaxCalculation;
using TaxCalculator.Services.TaxCalculation.Implementation;
using TaxCalculator.Services.Validation;
using TaxCalculator.Services.Validation.Implementation;

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
            serviceCollection.AddTransient<IDateService, DateService>();

            serviceCollection.AddTransient<ISalaryCalculator, SalaryCalculator>();
            serviceCollection.AddTransient<ITaxesCalculator, TaxesCalculator>();
            serviceCollection.AddTransient<ISalaryValidation, SalaryValidation>();

            return serviceCollection;
        }
    }
}
