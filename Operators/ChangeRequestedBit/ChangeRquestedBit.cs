using System;


namespace ChangeRequestedBit
{
    class ChangeRquestedBit
    {
        static void Main()
        {
            Console.WriteLine("Please insert a integer nubmer");
            int num = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Please insert which position to change ");
            int p = Convert.ToInt32(Console.ReadLine());


            Console.WriteLine("Please insert 0 or 1 to place ");
            int v = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Binary Enterd number was\n" + Convert.ToString(num, 2));
            if (v==1)
            {
                num=num|(1<<p);
              
            }
            else
            {
                num = num & ~(1 << p);
            }
            Console.WriteLine("New number is: " +num);
            Console.WriteLine("Binary:\n" + Convert.ToString(num,2));
        }

    }
}
