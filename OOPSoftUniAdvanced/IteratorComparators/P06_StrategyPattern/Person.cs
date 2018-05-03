using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace P06_StrategyPattern
{
    public class Person:IComparable<Person>, IPerson
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; private set; }
        public int Age  { get;private  set; }

        public int CompareTo(Person other)
        {
            var result = this.Name.Length.CompareTo(other.Name.Length);
            if (result == 0)
            {
                result = this.Name.ToLower()[0].CompareTo(other.Name.ToLower()[0]);
            }

            return result;
        }

        public override string ToString()
        {
            return $"{this.Name} {this.Age}";
        }
    }
}
