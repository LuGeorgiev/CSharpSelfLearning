using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Contracts;
using WildFarm.Contracts.Animals;

namespace WildFarm.Classes.Animals
{
    public class Owl : Bird, IBird
    {
        public Owl(string name,double wingSize, double weight)
        {
            this.Name = name;
            this.WingSize = wingSize;
            this.Weight = weight;
            this.FoodEaten = 0;
            this.eatableFoods = new List<FoodType>() {FoodType.Meat};
        }
        private ICollection<FoodType> eatableFoods;

        public override string Name { get; protected set; }

        public override double Weight { get; protected set; }

        public override int FoodEaten { get; protected set; }

        public override IReadOnlyCollection<FoodType> EatableFoods
        {
            get
            {
                return (IReadOnlyCollection<FoodType>)this.eatableFoods;
            }            
        }

        public override double WingSize { get; protected set; }

        public override void ProduceSound()
        {
            Console.WriteLine("Hoot Hoot");
        }

        public override void IncreaseWeight(IFood food)
        {
            bool canEatFood = eatableFoods.Contains(food.TypeFood);

            if (canEatFood)
            {
                this.Weight += 0.25 * food.Quantity;
                this.FoodEaten += food.Quantity;
            }
            else
            {
                Console.WriteLine($"{this.GetType().Name} does not eat {food.TypeFood.ToString()}!");
            }
        }
    }
}
