using System;
using System.Collections.Generic;
using System.Text;

namespace P04_ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> bagOfProducts;

        public List<Product> BagOfProducts
        {
            get { return bagOfProducts; }
            private set { bagOfProducts = value; }
        }
        public decimal Money
        {
            get { return money; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                money = value;
            }
        }
        public string Name
        {
            get { return name; }
            private set
            {
                if (value == null || value.Length == 0||value.Contains(" "))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                name = value;
            }
        }

        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;
            BagOfProducts = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            bool canAfford = this.Money >= product.Price;

            if (canAfford)
            {
                this.BagOfProducts.Add(product);
                this.Money -= product.Price;
                Console.WriteLine($"{this.Name} bought {product.Name}");
            }
            else
            {
                Console.WriteLine($"{this.Name} can't afford {product.Name}");
            }
        }

        public void PrintProducts()
        {
            if (this.BagOfProducts.Count>0)
            {
                Console.WriteLine(this.ToString()); 
            }
            else
            {
                Console.WriteLine($"{this.Name} - Nothing bought");
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($"{this.Name} - ");
            for (int i = 0; i < this.BagOfProducts.Count; i++)
            {
                if(i< this.BagOfProducts.Count-1)
                {
                    sb.Append(BagOfProducts[i].Name + ", ");
                }
                else
                {
                    sb.Append(BagOfProducts[i].Name);
                }
            }           
            return sb.ToString();
        }
    }
}
