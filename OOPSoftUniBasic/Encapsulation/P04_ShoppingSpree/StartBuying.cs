using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_ShoppingSpree
{
    public class StartBuying
    {
        static void Main(string[] args)
        {
            var listOfBuyers = new List<Person>();
            var listOfProducts = new List<Product>();

            var buyers = Console.ReadLine().Split(new[] { '=', ';' }, StringSplitOptions.RemoveEmptyEntries);
            var products = Console.ReadLine().Split(new[] { '=', ';' }, StringSplitOptions.RemoveEmptyEntries);
            try
            {
                listOfBuyers = InitializeBuyers(buyers);
                listOfProducts = InitializeProducts(products);

                var input = "";
                while ((input=Console.ReadLine())!="END")
                {
                    var personProduct = input.Split();
                    var buyerName = personProduct[0];
                    var productName = personProduct[1];

                    var personThatBuys = listOfBuyers.FirstOrDefault(x => x.Name == buyerName);
                    var productToBuy = listOfProducts.FirstOrDefault(x => x.Name == productName);
                    if (personThatBuys!=null&&productToBuy!=null)
                    {
                        personThatBuys.AddProduct(productToBuy);                        
                    }
                }
                foreach (var person in listOfBuyers)
                {
                    person.PrintProducts();
                }
            }
            catch (ArgumentException ex)
            {

                Console.WriteLine(ex.Message);
                return;
            }
        }

        private static List<Product> InitializeProducts(string[] products)
        {
            var productsList = new List<Product>();

            for (int i = 0; i < products.Length; i += 2)
            {
                var name = products[i];
                var cost = decimal.Parse(products[i + 1]);

                productsList.Add(new Product(name, cost));

            }
            return productsList;
        }

        private static List<Person> InitializeBuyers(string[] buyers)
        {
            var people = new List<Person>();

            for (int i = 0; i < buyers.Length; i+=2)
            {
                var name = buyers[i];
                var money = decimal.Parse(buyers[i + 1]);

                people.Add(new Person(name, money));

            }
            return people;
        }
    }
}
