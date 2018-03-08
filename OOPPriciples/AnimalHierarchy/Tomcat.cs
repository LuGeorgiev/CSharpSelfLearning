using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalHierarchy
{
    class Tomcat:Cat
    {
        public Tomcat(string name, int age, bool sex):base(name, age, sex)
        {
            this.Sex = true;
        }
        public override void Sound()
        {
            Console.WriteLine("Tocats's MURRRRRRR");
        }
    }
}
