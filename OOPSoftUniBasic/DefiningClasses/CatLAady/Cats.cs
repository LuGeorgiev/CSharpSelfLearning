using System;
using System.Collections.Generic;


    public class Cats
    {
        static void Main(string[] args)
        {
            var catWithInfo = new Dictionary<string, string>();
            var catWithBreed = new Dictionary<string, string>();

            var input = "";
            while ((input = Console.ReadLine()) != "End")
            {
                var catData = input.Split();
                var breed = catData[0];
                var name = catData[1];
                var info = catData[2];
                catWithBreed.Add(name, breed);
                catWithInfo.Add(name, info);
            }

            var catToDisplay = Console.ReadLine();
            if (catWithBreed[catToDisplay] != "Cymric")
            {
                Console.WriteLine(catWithBreed[catToDisplay] + " " + catToDisplay + " " + catWithInfo[catToDisplay]);
            }
            else
            {
                var furLength = double.Parse(catWithInfo[catToDisplay]);
                Console.WriteLine($"{catWithBreed[catToDisplay]} {catToDisplay} {furLength:F2}");

            }
        }
    }

