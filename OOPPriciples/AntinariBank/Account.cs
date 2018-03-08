using System;


namespace AntinariBank
{
    public enum CustomerType
    {
        company,
        individual
    }

    public abstract class Account
    {
        private string customerName;
        private CustomerType type;
        private decimal balance;
        private decimal intrestRate;

        public Account(string name, CustomerType type, decimal balance, decimal intrest)
        {
            this.CustomerName = name;
            this.Type = type;
            this.Balance = balance;
            this.IntrestRate = intrest;
        }

        public string CustomerName
        {
            get
            {
                return this.customerName;
            }
            protected set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name of the customer cannot be omitted");
                }
                this.customerName = value;
            }
        }
        public CustomerType Type
        {
            get
            {
                return this.type;
            }
            protected set
            {                
                this.type = value;
            }
        }
        public decimal Balance
        {
            get
            {
                return this.balance;
            }
            protected set
            {
                if (value<0)
                {
                    throw new ArgumentOutOfRangeException("Balance can only be positive");
                }
                this.balance = value;
            }
        }
        public decimal IntrestRate
        {
            get
            {
                return this.intrestRate;
            }
            protected set
            {
                if (value<0||value>5)
                {
                    throw new ArgumentNullException("Intrest reate is monthly base and have to be between 0 and 5%");
                }
                this.intrestRate = value;
            }
        }

        public abstract decimal CalculateIntrestAmount(int months);
        
    }
}
