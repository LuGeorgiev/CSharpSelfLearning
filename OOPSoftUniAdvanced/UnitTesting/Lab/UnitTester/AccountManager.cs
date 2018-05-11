using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTester
{
    public class AccountManager : IAccountManager
    {
        public BankAccount Account { get; private set; }

        public AccountManager(BankAccount bankAccount)
        {
            this.Account = bankAccount;
        }
        public int GetBalanceInCents()
        {
            return Account.Balance;
        }
    }
}
