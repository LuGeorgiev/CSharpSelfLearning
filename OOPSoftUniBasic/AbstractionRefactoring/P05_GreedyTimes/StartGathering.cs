using System;
using System.Collections.Generic;
using System.Linq;

namespace P05_GreedyTimes
{

    public class StartGathering
    {
        static void Main(string[] args)
        {
            long capacity = long.Parse(Console.ReadLine());
            var inventory = new Inventory(capacity);

            string[] input = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            

            for (int i = 0; i < input.Length; i += 2)
            {
                string booty = input[i];
                long quantity = long.Parse(input[i + 1]);

                string type = FindType(booty);               

                if (type == "")
                {
                    continue;
                }
                else if(type=="Cash")
                {
                    inventory.AddCash(quantity, booty);
                }
                else if (type == "Gold")
                {
                    inventory.AddGold(quantity);
                }
                else if (type == "Gem")
                {
                    inventory.AddGems(quantity, booty);
                }

            }

            inventory.PrintInventory();
        }

        private static string FindType(string booty)
        {
            if (booty.Length == 3)
            {
                return "Cash";
            }
            else if (booty.ToLower().EndsWith("gem"))
            {
                return "Gem";
            }
            else if (booty.ToLower() == "gold")
            {
                return "Gold";
            }

            return "";
        }
    }
}