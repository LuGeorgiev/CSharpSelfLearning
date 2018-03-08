using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pesho
{
    interface IAnimal
    {
        void Eat();
    }
    class Cat : IComparable<Cat>
    {
        public int Age { get; set; }

        public int CompareTo(Cat other)
        {
            throw new NotImplementedException();
        }
    }

    class Main
    {
        //public static void Main(string[] args)
        //{

        //var cat1 = new Cat { Age = 10 };
            
        //}
    }
}
