using System;
using System.Collections.Generic;
using System.Text;


    public class Person
    {
        private string name;
        private int age;
               

        public int Age
        {
            get { return this.age; }
            set { this.age = value; }
        }

        public string Name
        {
            get {return this.name; }
            set {this.name=value; }
        }
        public Person()
        {
            this.Name = "No name";
            this.Age = 1;
        }
        public Person(int age):this()
        {
            this.Age = age;
        }
        public Person(int age, string name)
        {
            this.Age = age;
            this.Name = name;
        }

    }

