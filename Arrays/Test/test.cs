using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class test
    {
        static void Main(string[] args)
        {

            var sum = decimal.Parse(Console.ReadLine());
            decimal kurs=0m;            
            decimal resul;
            string vhodna = Console.ReadLine();
            string izhodna = Console.ReadLine();
            string valuta="";

            if (vhodna==izhodna)
            {
                kurs = 1m;
            }
            if (vhodna== "BGN" && izhodna== "USD")
            {
                kurs = 1/1.79549m;
                valuta = "USD";
            }
            if (vhodna == "USD" && izhodna == "BGN")
            {
                kurs = 1.79549m;
                valuta = "BGN";
            }
            if (vhodna == "BGN" && izhodna == "EUR")
            {
                kurs = 1/1.95583m;
                valuta = "EUR";
            }
            if (vhodna == "EUR" && izhodna == "BGN")
            {
                kurs =  1.95583m;
                valuta = "BGN";
            }
            if (vhodna == "BGN" && izhodna == "GBP")
            {
                kurs = 1 / 2.53405m;
                valuta = "GBP";
            }
            if (vhodna == "GBP" && izhodna == "BGN")
            {
                kurs = 2.53405m;
                valuta = "BGN";
            } //
            if (vhodna == "USD" && izhodna == "GBP")
            {
                kurs = 1.79549m / 2.53405m;
                valuta = "GBP";
            }
            if (vhodna == "GBP" && izhodna == "USD")
            {
                kurs = 2.53405m/ 1.79549m;
                valuta = "USD";
            }
            if (vhodna == "USD" && izhodna == "EUR")
            {
                kurs = 1.79549m / 1.95583m;
                valuta = "EUR";
            }
            if (vhodna == "EUR" && izhodna == "USD")
            {
                kurs = 1.95583m / 1.79549m;
                valuta = "USD";
            }
            if (vhodna == "GBP" && izhodna == "EUR")
            {
                kurs = 2.53405m / 1.95583m;
                valuta = "EUR";
            }
            if (vhodna == "EUR" && izhodna == "GBP")
            {
                kurs = 1.95583m / 2.53405m;
                valuta = "GBP";
            }
                        
            resul = sum*kurs; 
           
            Console.WriteLine("{0:F2} {1}",resul,valuta);
            

        }
    }
}   