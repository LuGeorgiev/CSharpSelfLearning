using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUltiCastDelegat
{
    public delegate void Print(string str);

    class Starup
    {
        static void PrintStr(string str)
        {
            Console.WriteLine(str);
        }
        static void PrintUpperCase(string str)
        {
            Console.WriteLine(str.ToUpper());
        }


        static void Main(string[] args)
        {
            Print printAllThePrinting= PrintStr;
            printAllThePrinting += PrintStr;
            printAllThePrinting += PrintUpperCase;

            printAllThePrinting("Pesho");
        }
    }
}
