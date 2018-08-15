
using System.Collections.Generic;
using System.Text;

public class ShutDownCommand : Command
{  

    private readonly IHarvesterController harvesterController;
    private readonly IProviderController providerController;

    public ShutDownCommand(IList<string> arguments, IHarvesterController harvesterController, IProviderController providerController) : base(arguments)
    {
        this.harvesterController = harvesterController;
        this.providerController = providerController;
    }

    public override string Execute()
    {
        var sb = new StringBuilder();

        sb.AppendLine(string.Format(Constants.ShutDown));          
        sb.AppendLine(string.Format(Constants.TotalStoredEnergy, providerController.TotalEnergyProduced));
        sb.Append(string.Format(Constants.TotalMinedOre, harvesterController.OreProduced));

        return sb.ToString().Trim();
    }
}

