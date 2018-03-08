using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntinariBank
{
    class Loan:Account,IMoney
    {

        public Loan(string name, CustomerType type, decimal balance, decimal intrest)
        : base(name, type, balance, intrest)
        {
        }

        public override decimal CalculateIntrestAmount(int months)
        {           

            if (this.Type==CustomerType.company)
            {
                if (months <= 2)
                {
                    return 0;
                }
                return this.Balance * this.IntrestRate * (months-2); 
            }

            if (months<=3)
            {
                return 0;
            }

            return this.Balance * this.IntrestRate * (months-3);
        }

        public void DepositeMoney(decimal amount)
        {
            this.Balance += amount;
        }

        public void WithdrawMoney(decimal amount)
        {
            Console.WriteLine("You cannot withdraw from your loan");
        }
    }
}
