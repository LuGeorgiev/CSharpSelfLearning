using P05_KingsGambit;
using P05_KingsGambit.Contracts;
using P05_KingsGambit.Models;
using System;
using System.Collections.Generic;

namespace P05_KingsGambitExtended
{
    class Program
    {
        static void Main(string[] args)
        {
            IKing king = SetUpKing();

            Engine engine = new Engine(king);
            engine.Run();
        }

        private static IKing SetUpKing()
        {
            string kingName = Console.ReadLine();
            IKing king = new King(kingName, new List<ISubordinate>());

            string[] royalGuardNames = Console.ReadLine().Split();
            foreach (var name in royalGuardNames)
            {
                king.AddSubordinate(new RoyalGuard(name));
            }

            string[] footManNames = Console.ReadLine().Split();
            foreach (var name in footManNames)
            {
                king.AddSubordinate(new Footman(name));
            }

            return king;
        }
    }
}
