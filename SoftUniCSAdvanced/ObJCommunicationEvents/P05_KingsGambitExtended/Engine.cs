using P05_KingsGambit.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P05_KingsGambit
{
    public class Engine
    {
        private IKing king;
        public Engine(IKing king)
        {
            this.king = king;
        }

        public void Run()
        {
            string input = "";
            while ((input=Console.ReadLine())!="End")
            {
                var tokens = input.Split();
                string command = tokens[0];

                if (command == "Attack")
                {
                    king.GetAttacked();
                }
                else if (command == "Kill")
                {
                    string name = tokens[1];
                    ISubordinate subordinate = king
                        .Subordinate
                        .First(s => s.Name == name);

                    subordinate.TakeDmg();
                }
            }
        }
    }
}
