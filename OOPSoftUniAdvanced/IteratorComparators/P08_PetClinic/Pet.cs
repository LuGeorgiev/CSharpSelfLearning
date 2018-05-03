﻿using System;
using System.Collections.Generic;
using System.Text;

namespace P08_PetClinic
{
    public class Pet
    {
        public Pet(string name, int age, string kind)
        {
            this.Name = name;
            this.Age = age;
            this.Kind = kind;
        }
        public string Name { get;private set; }
        public int Age { get;private set; }
        public string Kind { get;private set; }

        public override string ToString()
        {
            return $"{this.Name} {this.Age} {this.Kind}";
        }
    }
}
