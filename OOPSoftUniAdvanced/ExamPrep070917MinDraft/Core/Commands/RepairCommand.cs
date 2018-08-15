using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class RepairCommand : Command
{
    private readonly IProviderController providerController;
    public RepairCommand(IList<string> arguments, IProviderController providerController) : base(arguments)
    {
        this.providerController = providerController;
    }

    public override string Execute()
    {
        double value = double.Parse(Arguments[0]);
        string result = this.providerController.Repair(value);

        return result;
    }
}

