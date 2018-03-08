using System;


namespace ChangeBits3and4and5
{
    class ChangeBits3and4and5
    {
        static void Main()
        {
            Console.WriteLine("Insert integer number");
            int num = int.Parse (Console.ReadLine());
            int bit3 = (int)num & (1<<3);
            int bit4 = (int)num & (1 << 4);
            int bit5 = (int)num & (1 << 5);
            int bit24 = (int)num & (1 << 24);
            int bit25 = (int)num & (1 << 25);
            int bit26 = (int)num & (1 << 26);
                                            
            num = (int)num & ~(1<<3);         
            num = (int)num & ~(1<<4);
            num = (int)num & ~(1<<5);
            num = (int)num & ~(1<<24);
            num = (int)num & ~(1<<25);
            num = (int)num & ~(1<<26);

            num = (int)num | (bit3 << 21);
            num = (int)num | (bit4 << 21);
            num = (int)num | (bit5 << 21);
            num = (int)num | (bit24 >> 21);
            num = (int)num | (bit25 >> 21);
            num = (int)num | (bit26 >> 21);

            Console.WriteLine("The new number is:" + num);

        }
    }
}
