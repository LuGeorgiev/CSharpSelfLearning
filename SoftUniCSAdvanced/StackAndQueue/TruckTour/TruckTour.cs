using System;
using System.Collections.Generic;
using System.Linq;

namespace TruckTour
{
    class TruckTour
    {
        static void Main()
        {
            var petrolStattions = int.Parse(Console.ReadLine());
            var truckTour = new Stack<string>();
            truckTour = IniatializeTour(petrolStattions);

            for (int i = 0; i < petrolStattions; i++)
            {
                bool canTruckFinish = CheckIfCanFinish(truckTour);
                if (canTruckFinish)
                {
                    Console.WriteLine(i);
                    break;
                }
                else
                {
                    truckTour.Pop();
                }
            }
        }

        private static bool CheckIfCanFinish(Stack<string> truckTour)
        {            
            var pastStations = new Stack<string>();

            var station = truckTour.Pop();
            pastStations.Push(station);
            long fuel = station.Split(' ').Select(x => long.Parse(x)).First();
            long distance = station.Split(' ').Select(x => long.Parse(x)).Last();

            while (true)
            {               
                if (fuel < distance)
                {
                    while (pastStations.Count > 0)
                    {
                        truckTour.Push(pastStations.Pop());
                    }
                    return false;
                }
                if (truckTour.Count==0)
                {
                    //final station was reached
                    break;
                }
                //next station calculations
                fuel -= distance;
                station = truckTour.Pop();
                pastStations.Push(station);
                fuel += station.Split(' ').Select(x => long.Parse(x)).First();
                distance = station.Split(' ').Select(x => long.Parse(x)).Last();

            }

            return true;
        }

        public static Stack<string> IniatializeTour(int stationsInfo)
        {
            var tourInfo = new Stack<string>();
            var temporaryStationIngo = new Stack<string>();
            for (int i = 0; i < stationsInfo; i++)
            {
                temporaryStationIngo.Push(Console.ReadLine());
            }
            for (int i = 0; i < stationsInfo; i++)
            {
                tourInfo.Push(temporaryStationIngo.Pop());                
            }

            return tourInfo;
        }
    }
}
