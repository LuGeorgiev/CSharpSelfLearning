using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class InspectCommand : Command
{
    
    private readonly IHarvesterController harvesterController;
    private readonly IProviderController providerController;

    public InspectCommand(IList<string> arguments, IHarvesterController harvesterController, IProviderController providerController) : base(arguments)
    {
        this.harvesterController = harvesterController;
        this.providerController = providerController;
    }

    public override string Execute()
    {
        int id = int.Parse(Arguments[0]);
        IEntity entity = this.harvesterController
            .Entities
            .FirstOrDefault(e=>e.ID==id);

        if (entity==null)
        {
            entity= this.providerController
            .Entities
            .FirstOrDefault(e => e.ID == id);

        }

       
        if (entity==null)
        {
            return string.Format(Constants.EntytyNotFound, id);
        }

        return entity.ToString();
    }
}

