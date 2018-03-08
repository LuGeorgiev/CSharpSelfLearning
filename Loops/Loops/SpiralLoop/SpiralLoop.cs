using System;


namespace SpiralLoop
{
    class SpiralLoop
    {
        static void Main()
        {
            Console.WriteLine("Enter square dimentions");
            int n = int.Parse(Console.ReadLine()); //dimensions
            int coll = 0;
            int row = 0;
            string direction = "right";

            int[,] spiral = new int[n, n];

            for (int i = 1; i <= n*n; i++)
            {
                if (direction== "right"&&(coll>n-1||spiral[row,coll]!=0)) //from right to down
                {
                    direction = "down";
                    coll--;
                    row++;
                }
                if (direction == "down" &&( row > n-1 || spiral[row, coll] != 0) ) //from down to left
                {
                    direction = "left";
                    row--;
                    coll--;
                }
                if (direction == "left" && (coll < 0 || spiral[row, coll] != 0)) //from left to up
                {
                    direction = "up";
                    coll++;
                    row--;
                }
                if (direction == "up" && (row < 0 || spiral[row, coll] != 0)) //from up to right
                {
                    direction = "right";
                    row++;
                    coll++;
                }


                spiral[row, coll] = i;

                if (direction=="right")
                {
                    coll++;
                }
                if (direction == "down")
                {
                    row++;
                }
                if (direction == "left")
                {
                    coll--;
                }
                if (direction == "up")
                {
                    row--;
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write("{0,4}", spiral[i,j]);
                }
                Console.WriteLine();
            }
            
        }
    }
}
