using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Contracts;

namespace WildFarm.Classes
{
    class Food : IFood
    {
        public Food(string foodType, int quantity )
        {
            this.Quantity = quantity;
            ParseFoodType(foodType);
        }

        private void ParseFoodType(string foodType)
        {
            bool correctInput = Enum.TryParse(typeof(FoodType), foodType, out object food);
            if (!correctInput)
            {
                throw new ArgumentException("Food Enumeration was not correct");
            }
                this.TypeFood = (FoodType)food;
        }

        public int Quantity { get; private set; }

        public FoodType TypeFood { get; private set; }
    }
}
