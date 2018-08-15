using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Command :ICommand
{
    public Command(IList<string> arguments)
    {
        this.Arguments = arguments;
    }

    public IList<string> Arguments { get; protected set; }

    public abstract string Execute();
   
}

