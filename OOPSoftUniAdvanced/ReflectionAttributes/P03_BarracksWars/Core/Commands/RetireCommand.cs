using System;
using System.Collections.Generic;
using System.Text;
using _03BarracksFactory.Contracts;

namespace _03BarracksWars.Core.Commands
{
    public class RetireCommand : Command
    {
        [Inject]
        private IRepository repository;

        public RetireCommand(string[] date, IRepository repository) 
            : base(date)
        {
            this.Repository = repository;
        }

        protected IRepository Repository
        {
            get { return this.repository; }
            private set { this.repository = value; }
        }

        public override string Execute()
        {
            string unitType = Data[1];
            try
            {
                this.Repository.RemoveUnit(unitType);
            }
            catch(Exception e)
            {
                throw new ArgumentException("No such unit in repository." ,e);
            }

            return unitType + " retired!";
        }
    }
}
