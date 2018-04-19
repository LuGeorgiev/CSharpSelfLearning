using System;
using System.Collections.Generic;
using System.Text;

namespace P01_Person
{
    public class Child : Person
    {
        public Child(string name, int age) : base(name, age)
        {
            if (age>=15)
            {
                throw new ArgumentException("Child's age must be less than 15!");
            }
        }
    }
}
