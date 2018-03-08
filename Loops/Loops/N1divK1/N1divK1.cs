using System;


namespace N1divK1
{
    class N1divK1
    {
        static void Main()
        {
            int k=5;
            int n=8;
            int result=1;

            for (int i = k; i <= n; i++)
            {
                result *= i;
            }

            Console.WriteLine(result);
        }
    }
}
