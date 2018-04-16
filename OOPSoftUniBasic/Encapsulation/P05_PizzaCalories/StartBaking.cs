using System;
using System.Linq;

namespace P05_PizzaCalories
{
    public class StartBaking
    {
        static void Main(string[] args)
        {
            try
            {
                var pizzaName = Console.ReadLine().Split().Last();
                var doughtInput = Console.ReadLine().Split();
                var dough = new Dough(doughtInput[1],doughtInput[2],int.Parse(doughtInput[3]));

                var pizza = new Pizza(pizzaName, dough);

                var inputToping = "";
                while ((inputToping=Console.ReadLine())!="END")
                {
                    var topping = inputToping.Split();
                    var toPutOnPizza = new Topping(int.Parse(topping[2]), topping[1]);
                    pizza.AddTopping(toPutOnPizza);
                }

                Console.WriteLine(pizza);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
           
        }
    }
}
