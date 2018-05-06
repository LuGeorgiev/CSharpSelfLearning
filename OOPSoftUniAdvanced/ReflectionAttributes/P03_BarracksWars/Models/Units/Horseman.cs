using _03BarracksFactory.Models.Units;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03_BarracksWars.Models.Units
{
    class Horseman:Unit
    {
        private const int DefaultHealth = 50;
        private const int DefaultDamage = 10;

        public Horseman() 
            : base(DefaultHealth, DefaultDamage)
        {
        }
    }
}
