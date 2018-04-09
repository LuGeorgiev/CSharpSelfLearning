using System;
using System.Collections.Generic;
using System.Linq;


    public class StartIntersecting
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var numOfRectangles = int.Parse(input[0]);
            var numOfIntersects = int.Parse(input[1]);

            var listOfRectangles = new List<Rectangle>();
            for (int i = 0; i < numOfRectangles; i++)
            {
                var rectangleInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var id = rectangleInfo[0];
                var width =double.Parse( rectangleInfo[1]);
                var height =double.Parse( rectangleInfo[2]);
                var xAx =double.Parse( rectangleInfo[3]);
                var yAx =double.Parse( rectangleInfo[4]);
                listOfRectangles.Add(new Rectangle(id, width, height, xAx, yAx));
            }

            bool areIntersected = false;
            for (int i = 0; i < numOfIntersects; i++)
            {
                var intersectInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var firstId = intersectInfo[0];
                var secondId = intersectInfo[1];
                Rectangle first = listOfRectangles.FirstOrDefault(x => x.Id == firstId);
                Rectangle second = listOfRectangles.FirstOrDefault(x => x.Id == secondId);

                areIntersected = Rectangle.AreRectanglesIntersected(first, second);
                if (areIntersected)
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine("false");
                }
            }
        }
    }

