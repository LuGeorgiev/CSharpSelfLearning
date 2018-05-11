using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTester
{
    public class Bank
    {
        private IAccountManager accountMnager;

        public Bank(IAccountManager accountMng)
        {
            this.accountMnager = accountMng;
        }

        public string GetAccountBalance()
        {

            return this.accountMnager.GetBalanceInCents().ToString("F2");
        }
    }
}
