using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using UnitTester;

namespace UnitTesterTests
{
    [TestFixture]
    public class BnakTests
    {
        [Test]
        public void GetAccountBalanceFormatsToMoney()
        {
            var bankAccount = new BankAccount(10);
            var accountManager = new AccountManager(bankAccount);
            var bank = new Bank(accountManager);


            string expected  = "10.00";

            Assert.That(bank.GetAccountBalance(), Is.EqualTo(expected));            
        }

        [Test]
        public void GetAccountBalanceFormatsToMoney_WithFakeAccountManger()
        {
            var bank = new Bank(new FakeAccountManager(10));             
                       
            string expected = "10.00";

            Assert.That(bank.GetAccountBalance(), Is.EqualTo(expected));
        }
        [Test]
        public void GetAccountBalanceFormatsToMoney_WithMockingLibrary()
        {
            var fakeAccountManger = new Mock<IAccountManager>();
            fakeAccountManger.Setup(m => m.GetBalanceInCents())
                .Returns(10);

            var bank = new Bank(fakeAccountManger.Object);

            string expected = "10.00";

            Assert.That(bank.GetAccountBalance(), Is.EqualTo(expected));
        }

        class FakeAccountManager : IAccountManager
        {
            private int centsToReturn;
            public FakeAccountManager(int cents)
            {
                this.centsToReturn = cents;
            }
            public int GetBalanceInCents()
            {
                return centsToReturn;
            }
        }
    }
}
