using System;
using System.Collections.Generic;
using System.Text;

namespace P01_Person
{
    public class Person
    {
        private int age;
        private string name;

        public string Name
        {
            get
            {
                return this.name;
            }
            protected set
            {
                if (value.Length<3)
                {
                    throw new ArgumentException("Name's length should not be less than 3 symbols!");
                }
                this.name = value;
            }
        }
        public int Age
        {
            get
            {
                return this.age;
            }
            protected set
            {
                if (value<0)
                {
                    throw new ArgumentException("Age must be positive!");
                }
                this.age = value;
            }
        }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public override string ToString()
        {
            return $"Name: {this.Name}, Age: {this.Age}";
        }
    }
}
