using System;



namespace DivisionBy3JaggedArrays
{
    class DivisionBy3JaggedArrays
    {
        static void Main()
        {
            int[] numbers = {2,3,4,6,7,8,9,5,32,22,34,44,7,89978,232,23,24,5,6,79, };
            int[] size = new int[3];
            int[] offset = new int[3];

            foreach (var number in numbers)
            {
                int reminder = number % 3;
                size[reminder]++;
            }

            int[][] numbersByReminder = new int[3][] {

                new int[size[0]],
                new int[size[1]],
                new int[size[2]]
            };

            foreach (var number in numbers)
            {
                int reminder = number % 3;
                numbersByReminder[reminder][offset[reminder]] = number;
                offset[reminder]++;
            }

            for (int i=0;i<numbersByReminder.GetLength(0);i++)
            {
                Console.WriteLine(String.Join(" ",numbersByReminder[i]));
            }

        }
    }
}
