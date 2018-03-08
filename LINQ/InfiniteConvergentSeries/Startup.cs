using System;


namespace InfiniteConvergentSeries
{
    delegate double InfiniteSeries(double precious);

    class Startup
    {
        static double FirstLine(double precious)
        {
            double sum = 1.0;
            double previousSum = 1.0;
            int member = 2;
            while (true)
            {
                sum += 1 / (double)member;
                if (sum-previousSum<precious)
                {
                    return sum;
                }
                previousSum = sum;
                member += 2;
            }                        
        }

        static double SecondLine(double precious)
        {
            double sum = 1.0;
            double previousSum = 1.0;
            int member = 2;
            double next = 1 / (double)member;
            while (true)
            {
                sum += next;
                if (sum - previousSum < precious)
                {
                    return sum;
                }
                previousSum = sum;
                member ++;
                next *= 1 / (double)member;
            }
        }

        static double ThirdLine(double precious)
        {
            double sum = 1.0;
            double previousSum = 1.0;
            int counter = 2;
            int baseLine = 2;
            while (true)
            {
                sum += Math.Pow(-1,counter)*1 / (double)baseLine;
                if (Math.Abs(sum - previousSum) < precious)
                {
                    return sum;
                }
                previousSum = sum;
                baseLine *= 2;
                counter ++;
            }
        }

        static void Main(string[] args)
        {
            InfiniteSeries first = FirstLine;
            Console.WriteLine(first(0.01));

            InfiniteSeries second = SecondLine;
            Console.WriteLine(second(0.01));

            InfiniteSeries third = ThirdLine;
            Console.WriteLine(third(0.001));
        }
    }
}
