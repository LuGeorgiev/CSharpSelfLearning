using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalHierarchy
{
    class Frog:Animal,IAnimal,ISound
    {
        public Frog(string name,bool sex, int age):base(name,age,sex)
        {
        }
        public void Sound()
        {
            Console.WriteLine("Kvak, Kvak");
        }
    }
}
