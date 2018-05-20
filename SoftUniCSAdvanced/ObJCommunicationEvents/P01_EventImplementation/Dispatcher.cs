using P01_EventImplementation.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01_EventImplementation
{
    
    public class Dispatcher : INameChangable
    {
        public event NameChangeEventHandler NameChange;

        private string name;

        public Dispatcher(string name)
        {
            this.name = name;
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.OnNameChange(new NameChangeEventArgs(value));
                this.name = value;
            }
        }

        public void OnNameChange(NameChangeEventArgs args)
        {
            if (this.NameChange!=null)
            {
                this.NameChange.Invoke(this,args);
            }
        }
    }
}
