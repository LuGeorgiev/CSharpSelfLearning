using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalHierarchy
{
    class Cat : Animal, IAnimal, ISound
    {
        public Cat(string name, int age, bool sex) :base(name,age,sex)
        {
        }
        public virtual void Sound()
        {
            Console.WriteLine("Miauuu, Murrr");
        }
    
    }
}
