using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainer
{
    class PokeTournament
    {
        static void Main()
        {
            var trainersList = new List<Trainer>();
            var input = "";
            while ((input=Console.ReadLine())!= "Tournament")
            {
                var currentTrainer = input.Split();
                var trainer = currentTrainer[0];
                var pokemon = currentTrainer[1];
                var elemental = currentTrainer[2];
                var pokemonHealth = double.Parse(currentTrainer[3]);
                bool pokemonWasAdded = false;
                foreach (var duelist in trainersList)
                {
                    if (duelist.Name == trainer)
                    {
                        pokemonWasAdded = true;
                        duelist.Pokemons.Add(new Pokemon(pokemon, elemental, pokemonHealth));
                    }
                }
                if (!pokemonWasAdded)
                {
                    trainersList.Add(new Trainer(trainer,pokemon,elemental,pokemonHealth));
                }
            }
            var action = "";
            while ((action=Console.ReadLine())!="End")
            {
                foreach (var trainer in trainersList)
                {
                    if (trainer.Pokemons.Any(x=>x.Element==action))
                    {
                        trainer.IncreaseBadge();
                    }
                    else
                    {
                        trainer.DecreaseHealth();
                    }
                }
            }

            var sortedTrainers = trainersList
                .OrderByDescending(x => x.Badges);

            foreach (var trainer in sortedTrainers)
            {
                Console.WriteLine($"{trainer.Name} {trainer.Badges} {trainer.Pokemons.Count}");
            }
        }
    }
}
