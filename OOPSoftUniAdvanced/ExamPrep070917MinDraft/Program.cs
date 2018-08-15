public class Program
{
    public static void Main(string[] args)
    {
        IEnergyRepository energyRepository = new EnergyRepository();
        IHarvesterFactory harvesterFactory = new HarvesterFactory();

        IHarvesterController harvestController = new HarvesterController(energyRepository,harvesterFactory);
        IProviderController providerController = new ProviderController(energyRepository);

        IReader reader = new ConsoleReader();
        IWriter writer = new ConsoleWriter();
        ICommandInterpreter commandInterptreter = new CommandInterpreter(harvestController,providerController);

        Engine engine = new Engine(commandInterptreter,reader,writer);
        engine.Run();
    }
}