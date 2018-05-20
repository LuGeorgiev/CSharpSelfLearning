using P01_EventImplementation.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01_EventImplementation
{
    public class Handler : INameChangeHandler
    {
        public void OnDispatcherNameChange(object sender, NameChangeEventArgs args)
        {
            Console.WriteLine($"{sender.GetType().Name}'s name changed to {args.Name}.");
        }
    }
}
