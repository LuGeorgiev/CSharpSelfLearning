using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberSystems
{
    class NumberSystemTest
    {
        static void Main(string[] args)
        {
            string test = Console.ReadLine();
            char[] bits = new char[test.Length];
            bits = test.ToCharArray();                    // NOTA BENNE               

            if (bits[0]=='1')
            {
                Console.WriteLine("KUR");
            }
            if (bits[1] == '1')
            {
                Console.WriteLine("Golqm KUR");
            }

            string kur = "Tupo";
            kur += bits[1];
            Console.WriteLine(kur);

        }
    }
}
