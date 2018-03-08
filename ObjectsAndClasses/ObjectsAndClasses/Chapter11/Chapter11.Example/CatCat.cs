using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter11.Chapter11.Example
{
    public class CatCat
    {
        private string name;

        private string color;

        private byte age;

        private byte lives;

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public string Color
        {
            get { return this.color; }
            set { this.color = value; }
        }

        public byte Age
        {
            get { return this.age; }
            set { this.age = value; }
        }

        public byte Lives
        {
            get { return this.lives; }
            set { this.lives = value; }
        }

        public CatCat()
        {
            this.name = "Unnamed";
            this.color = "grey";
            this.age = 1;
            this.lives = 7;
        }
        public CatCat(string name, byte age)
        {
            this.name = name;
            this.age = age;
        }

        static void SayMiau()
        {
            Console.WriteLine("{0} said: Fockkkk", CatCat.name);
        }
    }
}
