using System;
using System.Collections.Generic;
using System.Linq;

namespace P06_FutballTeamGenerator
{
    class GenerateTeams
    {
        static void Main(string[] args)
        {
            var listTeams = new List<Team>();            
            try
            {
                var input = "";
                while ((input=Console.ReadLine())!="END")
                {
                    var tokens = input.Split(';', StringSplitOptions.RemoveEmptyEntries);
                    if (tokens[0] == "Team")
                    {
                        AddTeam(listTeams, tokens);
                    }
                    else if (tokens[0] == "Add")
                    {
                        AddPlayerToTeam(listTeams, tokens);
                    }
                    else if (tokens[0] == "Remove")
                    {

                    }
                    else if (tokens[0] == "Rating")
                    {

                    }
                }

            }
            catch (ArgumentException ex)
            {
                string message = ex.Message;                
                Console.WriteLine(message);
            }
        }

        private static void AddPlayerToTeam(List<Team> listTeams, string[] tokens)
        {
            var teamName = tokens[1];
            var playerName = tokens[2];

            var findTeam = listTeams.FirstOrDefault(x => x.Name == teamName);
            if (findTeam==null)
            {
                throw new ArgumentException($"Team {teamName} does not exist.");
                return;
            }

            var newPlayer = new Player(playerName, int.Parse(tokens[3]), int.Parse(tokens[4]),
                int.Parse(tokens[5]), int.Parse(tokens[6]),int.Parse(tokens[7]));
            if (newPlayer==null)
            {
                throw new ArgumentException($"Player {playerName} is not in {teamName} team.");
                return;
            }

            findTeam.AddPlyer(newPlayer);
        }

        private static void AddTeam(List<Team> listTeams, string[] tokens)
        {
            listTeams.Add(new Team(tokens[1]));
        }
    }
}
