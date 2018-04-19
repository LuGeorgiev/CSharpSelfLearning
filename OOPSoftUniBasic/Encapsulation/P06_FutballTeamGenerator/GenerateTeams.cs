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
            
            var input = "";
            while ((input=Console.ReadLine())!="END")
            {
                try
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
                        RemovePlayerFromTeam(listTeams, tokens);
                    }
                    else if (tokens[0] == "Rating")
                    {
                        var teamToPrint = FindTeam(listTeams, tokens);
                        teamToPrint.PrintTeam();
                    }

                }
                catch (ArgumentException ex)
                {
                   Console.WriteLine(ex.Message);
                }
                
            }           
            
        }

        private static void RemovePlayerFromTeam(List<Team> listTeams, string[] tokens)
        {
            Team findTeam = FindTeam(listTeams, tokens);
            var playerName = tokens[2];

            var findPlayer = findTeam.Players
                .FirstOrDefault(x => x.Name == playerName);
            if (findPlayer == null)
            {
                throw new ArgumentException($"Player {playerName} is not in {findTeam.Name} team.");
            }
            else
            {
                findTeam.RemovePlayer(findPlayer);
            }

        }

        private static Team FindTeam(List<Team> listTeams, string[] tokens)
        {
            var teamName = tokens[1];            

            var findTeam = listTeams.FirstOrDefault(x => x.Name == teamName);
            if (findTeam == null)
            {
                throw new ArgumentException($"Team {teamName} does not exist.");                
            }

            return findTeam;
        }

        private static void AddPlayerToTeam(List<Team> listTeams, string[] tokens)
        {
            Team findTeam = FindTeam(listTeams, tokens);
            var playerName = tokens[2];

            var newPlayer = new Player(playerName, int.Parse(tokens[3]), int.Parse(tokens[4]),
                int.Parse(tokens[5]), int.Parse(tokens[6]),int.Parse(tokens[7]));
            if (newPlayer==null)
            {
                throw new ArgumentException($"Player {playerName} is not in {findTeam.Name} team.");                
            }
            else
            {
                findTeam.AddPlyer(newPlayer);
            }

        }

        private static void AddTeam(List<Team> listTeams, string[] tokens)
        {
            listTeams.Add(new Team(tokens[1]));
        }
    }
}
