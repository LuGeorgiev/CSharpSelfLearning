using System;

namespace ProstoChislo
{
    class ProstoChislo
    {
        static void Main()
        {
            Console.WriteLine("Моля въведете число за което да проверим дали е просто");
            int num = Convert.ToInt32(Console.ReadLine());
            int count = 0;

            for (int i = 2; i < Math.Sqrt(num); i++)
            {
                if((num%i)==0)
                {
                    count += 1;
                }
            }
            Console.WriteLine(count==0?"Числото е просто":"Числото НЕ е просто");
        }
    }
}
