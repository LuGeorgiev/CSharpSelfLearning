using P02_KingsGambit.Contracts;
using P02_KingsGambit.Models;
using System;
using System.Collections.Generic;

namespace P02_KingsGambit
{
    class StartUp
    {
        static void Main()
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
