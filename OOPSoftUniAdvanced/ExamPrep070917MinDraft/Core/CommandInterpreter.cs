using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

public class CommandInterpreter : ICommandInterpreter
{
    public CommandInterpreter(IHarvesterController harvesterController, IProviderController providerController)
    {
        HarvesterController = harvesterController;
        ProviderController = providerController;
    }

    public IHarvesterController HarvesterController { get; private set; }
    public IProviderController ProviderController { get; private set; }

    public string ProcessCommand(IList<string> args)
    {
        Command command = this.CreateCommand(args);

        string result = command.Execute();
        return result;
    }

    private Command CreateCommand(IList<string> args)
    {
        string commandName = args[0];

        Type commandType = Assembly.GetCallingAssembly()
            .GetTypes()
            .FirstOrDefault(t=>t.Name.Equals(commandName+"Command", StringComparison.InvariantCultureIgnoreCase));

        if (commandType==null)
        {
            throw new ArgumentException(string.Format(Constants.CommandNotFound, commandName));
        }

        if (!typeof(Command).IsAssignableFrom(commandType))
        {
            throw new InvalidOperationException(string.Format(Constants.InvalidCommand));
        }
        var ctor = commandType.GetConstructors().First();
        var paramsInfo = ctor.GetParameters();
        object[] parameters = new object[paramsInfo.Length];

        //this way we provide only needed parameters
        for (int i = 0; i < paramsInfo.Length; i++)
        {
            Type paramType = paramsInfo[i].ParameterType;
            if (paramType==typeof(IList<string>))
            {
                parameters[i] = args.Skip(1).ToList(); 
            }
            else
            {
                PropertyInfo paramInfo = this.GetType().GetProperties()
                    .FirstOrDefault(p=>p.PropertyType==paramType);
                parameters[i] = paramInfo.GetValue(this);
            }
        }

        //var arguments = args.Skip(1);
        //var instance = (ICommand)Activator.CreateInstance(commandType, arguments); 
        var instance = (Command)Activator.CreateInstance(commandType, parameters);
        return instance;
    }
}

