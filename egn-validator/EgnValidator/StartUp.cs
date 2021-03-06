﻿using EgnValidator.Implementations;
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
            serviceCollection.AddTransient<IDateTimeProvider, DateTimeProvider>();

            serviceCollection.AddTransient<IValidateEgn, ValidateEgn>();
            serviceCollection.AddTransient<IRegexService, RegexService>();
            serviceCollection.AddTransient<IControlSumService, ControlSumService>();
            serviceCollection.AddTransient<IDateService, DateService>();
            serviceCollection.AddTransient<IFutureDateService, FutureDateService>();
            serviceCollection.AddTransient<ILeapYearService, LeapYearService>();

            return serviceCollection;
        }
    }
}
