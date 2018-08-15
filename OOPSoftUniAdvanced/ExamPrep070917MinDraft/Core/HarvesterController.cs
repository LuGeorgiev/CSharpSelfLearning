using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class HarvesterController : IHarvesterController
{
    
    private IHarvesterFactory factory;
    private List<IHarvester> harvesters;
    private IEnergyRepository energyRepository;

    public HarvesterController(IEnergyRepository energyRepository, IHarvesterFactory factory)
    {
        this.energyRepository = energyRepository;
        this.factory = factory;

        this.harvesters = new List<IHarvester>();
        this.Mode = HarvestMode.Full;
    }
    public double OreProduced { get; private set; }
    private HarvestMode Mode { get;  set; }

    public IReadOnlyCollection<IEntity> Entities => (IReadOnlyCollection<IHarvester>)this.harvesters;

    public string ChangeMode(string mode)
    {
        bool isModeValid = Enum.TryParse<HarvestMode>(mode, true, out var newMode);

        if (!isModeValid)
        {
            throw new ArgumentException(string.Format(Constants.InvalidMode, mode));
        }

        var harvestersToRemove = new List<IHarvester>();

        foreach (var harvester in harvesters)
        {
            try
            {
                harvester.Broke();                
            }
            catch (Exception ex)
            {
                harvestersToRemove.Add(harvester);
            }
        }
        this.Mode = newMode;

        foreach (var entity in harvestersToRemove)
        {
            this.harvesters.Remove(entity);
        }

        string result = string.Format(Constants.SuccessfullyChangedMode, mode);
        return result;
    }

    public string Produce()
    {
        double neededEnergy = 0;
        double reduceBy = ReductionCoeficient();

        foreach (var harvester in this.harvesters)
        {            
           neededEnergy += harvester.EnergyRequirement*reduceBy;            
        }

        //check if we can mine
        double minedOre = 0;
        if (this.energyRepository.TakeEnergy(neededEnergy))
        {
            minedOre = harvesters.Sum(x => x.OreOutput)*reduceBy;
        }

        this.OreProduced += minedOre;

        string producedOre = string.Format(Constants.OreOutputToday, minedOre);
        return producedOre;
    }

    private double ReductionCoeficient()
    {
        double reductionCoefiecient = 1;
        if (this.Mode == HarvestMode.Half)
        {
            reductionCoefiecient = 0.5;
        }
        else if (this.Mode == HarvestMode.Energy)
        {
            reductionCoefiecient = 0.2;
        }

        return reductionCoefiecient;
    }

    public string Register(IList<string> args)
    {
        IHarvester harvester = factory.GenerateHarvester(args);
        this.harvesters.Add(harvester);

        string result = string.Format(Constants.SuccessfullyRegisterdHarvester, harvester.GetType().Name, harvester.ID);
        return result;
    }


    
}

