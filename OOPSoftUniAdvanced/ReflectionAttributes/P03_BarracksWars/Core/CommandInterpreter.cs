using System;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using _03BarracksFactory.Contracts;
using _03BarracksWars.Core.Commands;

namespace _03BarracksWars.Core
{
    class CommandInterpreter:ICommandInterpreter
    {
        private IServiceProvider serviceProvider;

        public CommandInterpreter(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public IExecutable InterpretCommand(string[] data, string commandName)
        {
            string result = string.Empty;

            Assembly assembly = Assembly.GetExecutingAssembly();
            Type commnadType = assembly.GetTypes()
                .FirstOrDefault(t => t.Name.ToLower() == commandName + "command");
            if (commnadType == null)
            {
                throw new ArgumentException("Invalid Command!");
            }

            if (!typeof(IExecutable).IsAssignableFrom(commnadType))
            {
                throw new ArgumentException("Command name is not command");
            }

            FieldInfo[] fieldsToInject = commnadType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(f => f.CustomAttributes.Any(ca => ca.AttributeType == typeof(InjectAttribute)))
                .ToArray();
            object[] injectArgs = fieldsToInject.Select(f => this.serviceProvider.GetService(f.FieldType))
                .ToArray();

            object[] constructorArgs = new object[] { data}.Concat(injectArgs).ToArray();

            IExecutable instance = (IExecutable)Activator.CreateInstance(commnadType, constructorArgs);

            return instance;
        }

    }
}
