using System;
using System.Collections.Generic;
using System.Text;

namespace P05_PizzaCalories
{
    public class Pizza
    {

        private string name;
        private List<Topping> toppings;
        public Dough Dough { get; set; }

        public string Name
        {
            get { return name; }
            private set
            {
                if (value.Length>15||value.Length==0)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                name = value;
            }
        }
        public List<Topping> Toppings
        {
            get { return toppings; }
            private set
            {                
                    toppings = value;                
            }
        }

        public Pizza(string name,Dough dought)
        {
            this.Dough = dought;
            Name = name;
            this.Toppings = new List<Topping>();
        }

        public void AddTopping(Topping topping)
        {
            if (this.Toppings.Count<10)
            {
                this.Toppings.Add(topping);
            }
            else
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }
        }

        public override string ToString()
        {
            decimal totalCalories = this.Dough.Calories;
            foreach (var topping in this.Toppings)
            {
                totalCalories += topping.Calories;
            }

            return $"{this.Name} - {totalCalories:F2} Calories.";
        }
    }
}
