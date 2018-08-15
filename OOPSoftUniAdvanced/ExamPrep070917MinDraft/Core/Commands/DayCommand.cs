using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class DayCommand : Command
{
    private readonly IHarvesterController harvesterController;
    private readonly IProviderController providerController;

    public DayCommand(IList<string> arguments, IHarvesterController harvesterController, IProviderController providerController) : base(arguments)
    {
        this.harvesterController = harvesterController;
        this.providerController = providerController;
    }

    public override string Execute()
    {
        string providersResult = this.providerController.Produce();
        string harvestResult = this.harvesterController.Produce();

        return (providersResult +  harvestResult).TrimEnd();
    }
}

