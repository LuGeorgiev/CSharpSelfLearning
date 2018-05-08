using System;
using System.Collections.Generic;

namespace P06_TrafficLights
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var listOfLights = new List<TrafficLight>();
            var lights = Console.ReadLine().Split();

            foreach (var light in lights)
            {
                listOfLights.Add(new TrafficLight(light));
            }           
                       

            int timesToSwitch = int.Parse(Console.ReadLine());
            for (int i = 0; i < timesToSwitch; i++)
            {
                foreach (var trafficLight in listOfLights)
                {
                    trafficLight.ChangeLights();
                    Console.Write(trafficLight);
                }
                Console.WriteLine();
            }
        }
    }
}
