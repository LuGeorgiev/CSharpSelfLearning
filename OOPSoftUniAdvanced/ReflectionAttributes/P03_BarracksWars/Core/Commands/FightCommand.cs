using System;
using System.Collections.Generic;
using System.Text;
using _03BarracksFactory.Contracts;

namespace _03BarracksWars.Core.Commands
{
    class FightCommand : Command
    {
        public FightCommand(string[] date) 
            : base(date)
        {
        }

        public override string Execute()
        {
            Environment.Exit(0);
            return null;
        }
    }
}
