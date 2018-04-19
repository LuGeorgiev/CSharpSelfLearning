using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P06_FutballTeamGenerator
{
    class Team
    {
        public List<Player> Players { get; private set; }
        private string name;

        public string Name
        {
            get { return name; }
            private set
            {
                if (value.Length == 0 || value == null || value.Contains(" "))
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                name = value;
            }
        }

        public Team(string name)
        {
            Name = name;
            this.Players = new List<Player>();
        }

        public bool AddPlyer(Player player)
        {
            //Exeption is to be handeled during Generation in MAIN()
            this.Players.Add(player);
            return true;
        }

        public void RemovePlayer(Player player)
        {
            var toRemove = this.Players.FirstOrDefault(x => x.Name == player.Name);
            if (toRemove==null)
            {
                throw new ArgumentException($"Player {player.Name} is not in {this.Name} team.");
            }
            else
            {
                this.Players.Remove(player);
            }
        }

        public void PrintTeam()
        {
            if (this.Players.Count==0)
            {
                throw new ArgumentException($"{this.Name} - 0");
            }

            int rating = (int)Math.Round(this.Players.Average(x => x.AvgStats));
            
            Console.WriteLine($"{this.Name} - {rating}");
        }

    }
}
