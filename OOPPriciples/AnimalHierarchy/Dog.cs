using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalHierarchy
{
    class Dog:Animal,IAnimal,ISound
    {
        public Dog(string name,int age,bool sex):base(name,age,sex)
        {
        }
        public void Sound()
        {
            Console.WriteLine("Bau Bau!!!");
        }
    }
}
