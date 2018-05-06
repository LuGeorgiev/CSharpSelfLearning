namespace _03BarracksFactory
{
    using _03BarracksWars.Core;
    using Contracts;
    using Core;
    using Core.Factories;
    using Data;
    using Microsoft.Extensions.DependencyInjection;
    using System;

    class AppEntryPoint
    {
        static void Main(string[] args)
        {
            IServiceProvider seviceprovider = ConfigureService();

            //WE do not need them after DI is set
            //IRepository repository = new UnitRepository();
            //IUnitFactory unitFactory = new UnitFactory();

            ICommandInterpreter commandInterpreter = new CommandInterpreter(seviceprovider);

            IRunnable engine = new Engine(commandInterpreter);
            engine.Run();
        }

        private static IServiceProvider ConfigureService()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddTransient<IUnitFactory, UnitFactory>(); // AddTransioent we use for Interfaces which are
            //not needed during whole program run i.e. Factories

            // Singleton guarantees that instance will be needed during whole program run
            services.AddSingleton<IRepository,UnitRepository>();

            IServiceProvider serviceProvider = services.BuildServiceProvider();
            return serviceProvider;
        }
    }
}
