using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTester
{
    public class BankAccount
    {
        public int Balance { get; private set; }

        public BankAccount(int initialBalance)
        {
            this.Balance = initialBalance;
        }

        public void Deposite(int amount)
        {
            this.Balance += amount;
        }

        public void Withdraw(int amount)
        {
            if (Balance<amount||amount<0)
            {
                throw new Exception("Insufficient finds");
            }
            this.Balance -= amount;
        }
    }
}
