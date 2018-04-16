using System;
using System.Collections.Generic;
using System.Text;

namespace P05_PizzaCalories
{
    enum Flour { White, Wholegrain };
    enum Baking { Crispy, Chewy, Homemade };

    public class Dough
    {
        private Flour PizzaFlour { get; set; }
        private Baking PizzaBaking { get; set; }

        private int weight;
        private decimal calories;

        public decimal Calories
        {
            get { return calories; }
            private set { calories = value; }
        }
        public int Weight
        {
            get { return weight; }
            private set
            {
                if (value<1||value>200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
                weight = value;
            }
        }

        public Dough(string pizzaFlour, string bakingTechnique, int weight)
        {
            try
            {
                this.PizzaFlour = (Flour)Enum.Parse(typeof(Flour), pizzaFlour,true);
                this.PizzaBaking = (Baking)Enum.Parse(typeof(Baking), bakingTechnique,true);               

            }
            catch (Exception)
            {

                throw new ArgumentException("Invalid type of dough."); 
            }
            Weight = weight;
            Calories = CalculateCalories();

        }

        private decimal CalculateCalories()
        {
            decimal calories = 2 * this.Weight;

            if (this.PizzaFlour==0)
            {
                calories = calories * 1.5m;
            }

            if ((int)this.PizzaBaking == 0)
            {
                calories = calories * 0.9m;
            }
            else if ((int)this.PizzaBaking == 1)
            {
                calories = calories * 1.1m;
            }

            return calories;
        }

        public override string ToString()
        {
            return $"{this.Calories:F2}";
        }
    }
}
