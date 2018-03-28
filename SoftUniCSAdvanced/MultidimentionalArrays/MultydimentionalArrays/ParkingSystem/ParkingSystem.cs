using System;
using System.Linq;

namespace ParkingSystem
{
    class ParkingSystem
    {
        static void Main()
        {
            var matrixDimention = Console.ReadLine();

            bool[,] parking = InitialzeParking(matrixDimention);

            var currentCar = Console.ReadLine();
            while (true)
            {
                if (currentCar=="stop")
                {
                    break;
                }
                int[] freeParkingLot = FindFreeSlot(parking, currentCar);
                if (freeParkingLot[1]==0)
                {
                    //no slot found
                    Console.WriteLine($"Row {freeParkingLot[0]} full");
                }
                else
                {
                    int distanceToPass = CalculateDistance(currentCar, freeParkingLot);
                    Console.WriteLine(distanceToPass);
                    parking[freeParkingLot[0], freeParkingLot[1]] = true;
                }

                currentCar = Console.ReadLine();
            }
            //Console.WriteLine(parking[0,0]);
            //Console.WriteLine(parking[2,2]);
        }

        private static int CalculateDistance(string currentCar, int[] freeParkingLot)
        {
            var carInfo = currentCar
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var initialRow = carInfo[0];            
            var initialCol = 0;
            var parkingRow = freeParkingLot[0]; 
            var parkingCol = freeParkingLot[1];

            var distancePassed = Math.Abs(parkingRow - initialRow) + Math.Abs(parkingCol- initialCol) + 1;

            return distancePassed;
        }

        private static int[] FindFreeSlot(bool[,] parking, string currentCar)
        {
            var carInfo = currentCar
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var initialRow = carInfo[0];
            var targetRow = carInfo[1];
            var targetCol = carInfo[2];
            var parkingRows = parking.GetLength(0);
            var parkingCols = parking.GetLength(1);
            var freeSlot = new int[2];

            if (parking[targetRow,targetCol]==false)
            {
                freeSlot[0] = targetRow;
                freeSlot[1] = targetCol;
                return freeSlot;
            }
            else
            {
                for (int distance = 1; distance < parkingCols-1; distance++)
                {
                    if (1 <= targetCol - distance 
                        && parking[targetRow, targetCol - distance] == false)
                    {
                        freeSlot[0] = targetRow;
                        freeSlot[1] = targetCol - distance;
                        return freeSlot;
                    }
                    else if (targetCol + distance < parkingCols
                        && parking[targetRow, targetCol + distance] == false)
                    {
                        freeSlot[0] = targetRow;
                        freeSlot[1] = targetCol + distance;
                        return freeSlot;
                    }
                }
            }
            freeSlot[0] = targetRow;
            return freeSlot;
        }

        private static bool[,] InitialzeParking(string matrixDimention)
        {
            var parkRow = matrixDimention
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .FirstOrDefault();
            var parkCol = matrixDimention
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .LastOrDefault();

            var parkingLots = new bool[parkRow, parkCol];

            return parkingLots;
        }
    }
}
