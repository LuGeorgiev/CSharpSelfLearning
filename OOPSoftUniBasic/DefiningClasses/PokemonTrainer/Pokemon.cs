using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonTrainer
{
    class Pokemon
    {
        public string Name { get; private set; }
        public string Element { get; private set; }
        public double Health { get;  set; }

        public Pokemon(string name, string element, double health)
        {
            this.Name = name;
            this.Element = element;
            this.Health = health;
        }
    }
}
