using System;
using System.Collections.Generic;
using System.Text;

namespace P04_ShoppingSpree
{
    public class Product
    {
        private string name;
        private decimal price;

        public decimal Price
        {
            get { return price; }
            private set
            {
                if (value<0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                price = value;
            }
        }
        public string Name
        {
            get { return name; }
            private set
            {
                if (value == null||value.Length==0||value.Contains(" "))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                name = value;
            }
        }

        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

    }
}
