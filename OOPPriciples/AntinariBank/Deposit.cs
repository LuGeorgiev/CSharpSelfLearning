

namespace AntinariBank
{
    class Deposit:Account,IMoney
    {
        public Deposit(string name, CustomerType type,decimal balance, decimal intrest)
            :base(name,type,balance,intrest)
        {           
        }

        public override decimal CalculateIntrestAmount(int months)
        {           

            if (this.Balance < 1000)
            {
                return 0;
            }            

            return this.Balance * this.IntrestRate * months * (-1);            
        }

        public void DepositeMoney(decimal amount)
        {
            this.Balance += amount;
        }
        public void WithdrawMoney(decimal amount)
        {
            this.Balance -=amount;
        }
    }
}
