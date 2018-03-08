using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalHierarchy
{
    class Animal:IAnimal
    {
        private int age;
        private string name;
        private bool sex=true;

        public int Age
        {
            get
            {
                return this.age;
            }
            protected set
            {
                if (value<=0||value>100)
                {
                    throw new ArgumentOutOfRangeException("Age have to be between 0 and 100 yeras");
                }
                this.age = value;
            }
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            protected set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name cannot be null"); 
                }
                this.name = value;
            }
        }
        public bool Sex
        {
            get
            {
                return this.sex;
            }
            protected set
            {
                this.sex = value;
            }
        }

        public Animal(string name, int age, bool sex)
        {
            this.Name = name;
            this.Age = age;
            this.Sex = sex;
        }        
    }
}
