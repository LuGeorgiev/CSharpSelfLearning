using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Contracts;
using WildFarm.Contracts.Animals;

namespace WildFarm.Classes.Animals
{
    public class Hen : Bird, IBird
    {
        private ICollection<FoodType> eatableFood;

        public Hen(string name, double wingSize, double weight)
        {
            this.Name = name;
            this.WingSize =wingSize;
            this.Weight = weight;
            this.eatableFood = new List<FoodType>() {FoodType.Fruit,FoodType.Meat,FoodType.Seeds,FoodType.Vegetable };
        }
        public override double WingSize { get ; protected set ; }
        public override string Name { get ; protected set ; }
        public override double Weight { get ; protected set ; }

        public override IReadOnlyCollection<FoodType> EatableFoods
        {
            get
            {
                return (IReadOnlyCollection<FoodType>)this.eatableFood;
            }
        }

        public override int FoodEaten { get ; protected set; }

        public override void IncreaseWeight(IFood food)
        {
            bool canEatFood = eatableFood.Contains(food.TypeFood);

            if (canEatFood)
            {
                this.Weight += 0.35 * food.Quantity;
                this.FoodEaten += food.Quantity;
            }
            else
            {
                Console.WriteLine($"{this.GetType().Name} does not eat {food.TypeFood.ToString()}!");
            }
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Cluck");
        }
    }
}
