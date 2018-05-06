using System;
using System.Collections.Generic;
using System.Text;
using _03BarracksFactory.Contracts;


namespace _03BarracksWars.Core.Commands
{
    public abstract class Command : IExecutable
    {
        private string[] date;       

        public Command(string[] date)
        {
            this.Data = date;           
        }

        protected string[] Data
        {
            get { return this.date; }
            private set { this.date = value; }
        }


        public abstract string Execute();
        
    }
}
