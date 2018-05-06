using System;
using System.Collections.Generic;
using System.Text;
using _03BarracksFactory.Contracts;

namespace _03BarracksWars.Core.Commands
{
    class ReportCommand : Command
    {
        [Inject]
        private IRepository repository;

        public ReportCommand(string[] date, IRepository repository) 
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
            string output = this.Repository.Statistics;
            return output;
        }
    }
}
