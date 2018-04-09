using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PokemonTrainer
{
    class Trainer
    {
        public string Name { get; private set; }
        public int Badges { get; private set; }
        public List<Pokemon> Pokemons { get; private set; }

        public Trainer(string name, string pokeName, string elemental, double health)
        {
            this.Name = name;
            this.Badges = 0;
            this.Pokemons = new List<Pokemon> {new Pokemon(pokeName,elemental,health)};
        }

        public void AddPokemon(string name, string element, double health)
        {
            this.Pokemons.Add(new Pokemon(name, element,health));
        }
        public void DecreaseHealth()
        {            
            for (int i = this.Pokemons.Count-1; i >=0; i--)
            {
                this.Pokemons[i].Health -= 10;
                if (this.Pokemons[i].Health<=0)
                {
                    Pokemons.RemoveAt(i);
                }
            }            
        }

        public void IncreaseBadge()
        {
            this.Badges++;
        }
    }
}
