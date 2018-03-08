using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntinariBank
{
    class Mortage : Account, IMoney
    {
        public Mortage(string name, CustomerType type, decimal balance, decimal intrest)
        : base(name, type, balance, intrest)
        {
        }

        public override decimal CalculateIntrestAmount(int months)
        {
            if (this.Type==CustomerType.company)
            {
                if (months<=12)
                {
                    return this.Balance * (this.IntrestRate / 2m) * months;
                }
                else
                {
                    return this.Balance * (this.IntrestRate / 2m) * 12 + this.Balance * this.IntrestRate * (months - 12);
                }

            }

            if (months<=6)
            {
                return this.Balance * (this.IntrestRate / 2m) * months;
            }

            return this.Balance * (this.IntrestRate/2m) * 6 + this.Balance*this.IntrestRate*(months-6);
        }

        public void DepositeMoney(decimal amount)
        {
            this.Balance += amount;
        }

        public void WithdrawMoney(decimal amount)
        {
            Console.WriteLine("You cannot withdraw from your MOrtage");
        }
    }
}
