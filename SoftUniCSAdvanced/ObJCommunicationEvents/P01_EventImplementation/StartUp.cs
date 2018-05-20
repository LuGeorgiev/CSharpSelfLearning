using P01_EventImplementation.Contracts;
using System;

namespace P01_EventImplementation
{
    class StartUp
    {
        static void Main(string[] args)
        {
            INameChangable dispatcher = new Dispatcher("Pesho");
            INameChangeHandler handler = new Handler();
            dispatcher.NameChange += handler.OnDispatcherNameChange;

            string input ="";
            while ((input=Console.ReadLine())!="END")
            {
                dispatcher.Name = input;
            }
        }
    }
}
