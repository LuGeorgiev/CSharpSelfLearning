using NUnit.Framework;
using System;
using UnitTester;

namespace UnitTesterTests
{
    [TestFixture]
    public class BandAccoutTests
    {
        [Test]
        public void DepositShouldIncreaseBalance()
        {
            var bankAccount = new BankAccount(0);

            bankAccount.Deposite(10);

            //Assert.That(bankAccount.Balance, Is.EqualTo(9));

            Assert.AreEqual(10, bankAccount.Balance);
        }

        [Test]
        public void WithdrawTest()
        {
            
            var bankAccount = new BankAccount(0);
            bankAccount.Deposite(10);

            bankAccount.Withdraw(2);

            Assert.AreEqual(8, bankAccount.Balance);
            
        }

        [TestCase(10)]
        [TestCase(100)]
        [TestCase(-10)]
        public void WithrowThrowsExceptionIfUnsoficientAmount(int amount)
        {
            var bankAccount = new BankAccount(0);            

            Assert.Throws<Exception>(()=>bankAccount.Withdraw(amount));
        }
    }
}
