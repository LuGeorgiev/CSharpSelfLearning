using System;
using System.Collections.Generic;
using System.Text;

namespace P05_PizzaCalories
{
    enum ToppingType {Meat, Veggies,Cheese,Sauce};

    public class Topping
    {
        private int weight;
        private ToppingType type;
        private decimal calories;

        public decimal Calories
        {
            get { return calories; }
            private set { calories = value; }
        }
        internal ToppingType Type
        {
            get { return type; }
            private set { type = value; }
        }
        public int Weight
        {
            get { return weight; }
            private set
            {
                if (value<1||value>50)
                {
                    throw new ArgumentException($"{this.Type} weight should be in the range [1..50].");
                }
                weight = value;
            }
        }

        public Topping(int weight, string topping)
        {
            try
            {
                this.Type = (ToppingType)Enum.Parse(typeof(ToppingType), topping,true);
            }
            catch (Exception)
            {
                throw new ArgumentException($"Cannot place {topping} on top of your pizza.");
            }
            this.Weight = weight;
            this.Calories = CalculateCalories();

        }

        private decimal CalculateCalories()
        {
            decimal calories = 2 * this.Weight;            

            if ((int)this.Type == 0)
            {
                calories = calories * 1.2m;
            }
            else if ((int)this.Type == 1)
            {
                calories = calories * 0.8m;
            }
            else if ((int)this.Type == 2)
            {
                calories = calories * 1.1m;
            }
            else if ((int)this.Type == 3)
            {
                calories = calories * 0.9m;
            }

            return calories;
        }

        public override string ToString()
        {
            return $"{this.Calories:F2}";
        }
    }
}
