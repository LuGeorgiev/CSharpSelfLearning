using EgnValidator.Implementations;
using EgnValidator.Services;
using EgnValidator.Services.Infrastructure;
using EgnValidator.Services.Infrastructure.Implementations;
using EgnValidator.Services.Validations;
using EgnValidator.Services.Validations.Implementations;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace EgnValidator
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            IServiceCollection serviceCollection = CreateCollection();
            IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

            var engine = serviceProvider.GetService<IEngine>();
            engine.Run();
        }

        private static IServiceCollection CreateCollection()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddSingleton<IEngine, Engine>();

            serviceCollection.AddTransient<IReader, ConsoleReader>();
            serviceCollection.AddTransient<IWriter, ConsoleWriter>();
            serviceCollection.AddTransient<IExtractDate, ExtractDate>();

            serviceCollection.AddTransient<IValidateEgn, ValidateEgn>();
            serviceCollection.AddTransient<IRegexService, RegexService>();
            serviceCollection.AddTransient<IControlSum, ControlSum>();
            serviceCollection.AddTransient<IDateService, DateService>();
            serviceCollection.AddTransient<IFutureDate, FutureDate>();
            serviceCollection.AddTransient<ILeapYear, LeapYear>();

            return serviceCollection;
        }
    }
}
