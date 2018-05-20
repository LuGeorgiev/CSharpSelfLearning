using System;
using System.Collections.Generic;
using System.Text;

namespace P01_EventImplementation.Contracts
{
    public delegate void NameChangeEventHandler(object sender, NameChangeEventArgs args);
    public interface INameChangable
    {
        string Name { get; set; }

        event NameChangeEventHandler NameChange;
        void OnNameChange(NameChangeEventArgs args);
    }
}
