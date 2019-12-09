using System;
using System.Collections.Generic;

namespace TypeDict
{
    class Program
    {
        static void Main(string[] args)
        {
            var dictByType = new Dictionary<Type, int>();
            var firstNum = 1;
            var secondNum = 3;
            Type typeFirst = firstNum.GetType();
            Type typeSecond = secondNum.GetType();

            dictByType.Add(typeFirst,firstNum);
            Console.WriteLine(dictByType.ContainsKey(typeSecond));
            Console.WriteLine(typeFirst.GetHashCode());
            Console.WriteLine(typeSecond.GetHashCode());

            var dog1 = new Dog { Name="Pesho", Age = 1 };
            var dog2 = new Dog { Name="Pesho", Age = 1 };
            Console.WriteLine("Dogs");
            Console.WriteLine(dog1.GetHashCode());
            Console.WriteLine(dog2.GetHashCode());
        }

        public class Dog
        {
            public string Name { get; set; }

            public int Age { get; set; }
        }
    }
}
