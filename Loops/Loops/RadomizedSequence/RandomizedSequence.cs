using System;


namespace RadomizedSequence
{
    class RandomizedSequence
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] sequence = new int[0];
            Random rand = new Random();
            int m;
            int l;

            Array.Resize(ref sequence, n);


            for (int i = 0; i < n; i++)
            {
                sequence[i] = i + 1;
                Console.Write("{0,-4}",sequence[i]);
            }
            Console.WriteLine();

            for (int i = 0; i < 2*n; i++)
            {
                m = rand.Next(n);
                l = rand.Next(n);
                if (m!=l)
                {
                    sequence[m] ^= sequence[l];
                    sequence[l] ^= sequence[m];
                    sequence[m] ^= sequence[l];
                }                
                
            }

            for (int i = 0; i < n; i++)
            {
               
               Console.Write("{0,-4}", sequence[i]);
            }
            Console.WriteLine();

        }
    }
}
