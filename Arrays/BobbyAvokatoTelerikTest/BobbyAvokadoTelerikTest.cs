using System;


namespace BobbyAvokatoTelerikTest
{
    class BobbyAvokadoTelerikTest
    {
        static void Main()
        {
            uint bobbyHead = uint.Parse(Console.ReadLine());
            int combCount = int.Parse(Console.ReadLine());
            uint comb;
            uint tempComb = 0;
            uint bestComb=0;
            uint mask = 1;

            for (int i = 0; i < combCount; i++)
            {
                comb = uint.Parse(Console.ReadLine());
                for (int j = 0; j < 32; j++)
                {
                    
                    if ((bobbyHead & comb & (mask << j))!=0)
                    {
                        tempComb = 0;
                        break;                       
                    }
                    else if((((bobbyHead^comb)&(mask<<j))!=0)&&((comb&(mask<<j))!=0))
                    {
                        tempComb++;
                    }

                }

                if (bestComb<tempComb)
                {
                    bestComb = comb;
                }

            }

            Console.WriteLine(bestComb);
        }
    }
}
