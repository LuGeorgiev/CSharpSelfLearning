using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntinariBank
{
    class Program
    {
        static void Main()
        {
            IMoney[] accounts = new IMoney[] 
            {
                new Deposit("Ivan Milev",CustomerType.individual,23000,0.01m),
                new Mortage("Ivan Milev",CustomerType.individual,3333000,0.03m),
                new Loan("Milen Ivanov",CustomerType.individual,5000,0.12m),
                new Deposit("Mariela Milenova",CustomerType.individual,6060,0.02m),
                new Mortage("Misho Ivankov",CustomerType.individual,234000,0.09m),
                new Mortage("Process",CustomerType.company,230000000,0.0156m),
                new Deposit("CEZ-Sofia",CustomerType.company,34000000,0.001m),
                new Loan("Telenor",CustomerType.company,20103000,0.31m),
                new Deposit("Mihaela Misheva",CustomerType.individual,3000,1.01m),
                new Loan("Lud Za Vruzvane",CustomerType.individual,200,3.0m)
            };

            decimal profit = 0;
            foreach (IMoney item in accounts)
            {
                profit+=item.CalculateIntrestAmount(24);
            }
            Console.WriteLine(profit);
        }
    }
}
