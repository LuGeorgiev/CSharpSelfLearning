using System;


namespace BiggestFromFive
{
    class BiggestFromFive
    {
        static void Main()
        {
            float[] num = { 144.4f, 3.7f, 9f, 23.4f, 0.6f };
            float maxValue=num[0];

            for (int i = 0; i < 5; i++)
            {
                if (num[i]>maxValue)
                {
                    maxValue = num[i];
                }
            }
            Console.WriteLine(maxValue);
        }
    }
}
