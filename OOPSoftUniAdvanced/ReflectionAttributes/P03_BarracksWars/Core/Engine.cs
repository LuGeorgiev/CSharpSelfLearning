namespace _03BarracksFactory.Core
{
    using System;
    using System.Reflection;
    using System.Linq;
    using Contracts;

    class Engine : IRunnable
    {        
        private ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
           
        }
        
        public void Run()
        {
            while (true)
            {
                try
                {
                    string input = Console.ReadLine();
                    string[] data = input.Split();
                    string commandName = data[0];
                    IExecutable command = commandInterpreter.InterpretCommand(data, commandName);

                    MethodInfo method = typeof(IExecutable).GetMethods().First();

                    try
                    {
                        string result = (string)method.Invoke(command, null);  //Execute do not need parammeters                        
                        Console.WriteLine(result);
                    }
                    catch (TargetInvocationException e)
                    {

                        throw e.InnerException;
                    }
                }
                
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }     
        
        
    }
}
