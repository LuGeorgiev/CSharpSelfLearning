namespace FestivalManager
{
    using System;
    using System.IO;
	using System.Linq;
	using Core;
	using Core.Contracts;
	using Core.Controllers;
	using Core.Controllers.Contracts;
	using Core.IO;
	using Core.IO.Contracts;
	using Entities;
	using Entities.Contracts;
    using FestivalManager.Entities.Factories;
    using FestivalManager.Entities.Factories.Contracts;
    using FestivalManager.Entities.Sets;
    using Microsoft.Extensions.DependencyInjection;

    public static class StartUp
	{
		public static void Main(string[] args)
		{
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            IStage stage = new Stage();
            IInstrumentFactory instrumentFactory = new InstrumentFactory();
            IPerformerFactory performerFactory = new PerformerFactory();
            ISetFactory setFactory = new SetFactory();
            ISongFactory songFactory = new SongFactory();

            IFestivalController festivalCоntroller = new FestivalController(stage,instrumentFactory,performerFactory,setFactory,songFactory);
            ISetController setCоntroller = new SetController(stage);

            //var engine = new Engine(festivalController, setController);
            //IServiceProvider serviceProvider = ConfigureServices();

            var engine = new Engine(reader,writer,festivalCоntroller,setCоntroller);
			engine.Run();
		}

        private static IServiceProvider ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<IEngine, Engine>();
            services.AddSingleton<IFestivalController, FestivalController>();

            services.AddSingleton<IReader, ConsoleReader>();
            services.AddSingleton<IWriter, ConsoleWriter>();

            services.AddTransient<ISetController, SetController>();
            services.AddTransient<ISetController, SetController>();
            services.AddSingleton<IInstrumentFactory, InstrumentFactory>();
            services.AddSingleton<IPerformerFactory, PerformerFactory>();
            services.AddSingleton<ISetFactory, SetFactory>();
            services.AddSingleton<ISongFactory, SongFactory>();

            IServiceProvider serviceProvider = services.BuildServiceProvider();
            return serviceProvider;
        }
    }
}