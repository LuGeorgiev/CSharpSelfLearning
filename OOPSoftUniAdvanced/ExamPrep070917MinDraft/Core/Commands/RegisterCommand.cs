

using System;
using System.Collections.Generic;
using System.Linq;

public class RegisterCommand : Command
{
    private const string harvesterName = nameof(Harvester);
    private const string providerName = nameof(Provider);

    private readonly IHarvesterController harvesterController;
    private readonly IProviderController providerController;
    public RegisterCommand(IList<string> arguments, IHarvesterController harvesterController, IProviderController providerController) : base(arguments)
    {
        this.harvesterController = harvesterController;
        this.providerController = providerController;
    }

    public override string Execute()
    {
        string result = null;
        string entityType = this.Arguments[0];
        // Refactor with reflection
        if (entityType.Equals(harvesterName,StringComparison.InvariantCultureIgnoreCase))
        {
            result = this.harvesterController.Register(this.Arguments.Skip(1).ToList());
        }
        else if(entityType.Equals(providerName, StringComparison.InvariantCultureIgnoreCase))
        {
            result = this.providerController.Register(this.Arguments.Skip(1).ToList());
        }

        return result;
    }
}

