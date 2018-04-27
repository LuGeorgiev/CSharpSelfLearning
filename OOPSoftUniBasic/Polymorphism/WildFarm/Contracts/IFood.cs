using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Contracts
{
    public interface IFood
    {
        int Quantity { get; }
        FoodType TypeFood { get; }
    }
}
