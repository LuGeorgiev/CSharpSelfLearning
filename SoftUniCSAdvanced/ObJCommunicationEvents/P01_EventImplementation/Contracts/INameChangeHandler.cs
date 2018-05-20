using System;
using System.Collections.Generic;
using System.Text;

namespace P01_EventImplementation.Contracts
{
    public interface INameChangeHandler
    {
        void OnDispatcherNameChange(object sender, NameChangeEventArgs args);
    }
}
