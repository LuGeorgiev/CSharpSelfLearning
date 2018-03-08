using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var cat1 = new Cat();
            //cat1.Age = 10;
            //var cat2 = new Cat();
            //cat2.Age = 10;
            //Console.WriteLine(cat1==cat2);

            //var owner = new Owner();
            //owner.Name = "pesho";
            //owner.Cats.Add(new Cat { Age = 10 });
            //owner.Cats.Add(new Cat { Age = 1 });
            //owner.Cats.Add(new Cat { Age = 8 });
            //owner.Cats.Add(new Cat { Age = 6 });
            //Console.WriteLine(owner.Cats.Count);

            var owner = new Owner();
            var prop = typeof(Console).GetMethods();
            foreach (var item in prop)
            {
                Console.WriteLine(item.Name);
            }
        }

        public class Owner: ICloneable
        {
            public string Name { get; set; }
            public IList<Cat> Cats { get; set; }

            object ICloneable.Clone()
            {
                throw new NotImplementedException();
            }
            public Owner Clone()
            {
                var owner = new Owner();
                owner.Name = this.Name;
                owner.Cats = new List<Cat>();
                foreach (var cat in this.Cats)
                {
                    var clonedCat = new Cat();
                    clonedCat.Age = cat.Age;
                    owner.Cats.Add(clonedCat);
                }
                return owner;
            }

            public Owner Memberwise()
            {
                return (Owner)this.Memberwise();
            }
        }

        public class Cat  // ICloneable
        {
            public int Age { get; set; }

            //public object Clone()
            //{
            //    var clone = new Cat()
            //    {
            //        Age = this.Age
            //    };
            //    return clone;
            //}

            public Cat Memberwise()
            {
                return (Cat)this.Memberwise();
            }
            //public Cat()
            //{

            //}
            //public static bool operator ==(Cat firstCat, Cat seconCat)
            //{
            //    return Cat.Equals(firstCat, seconCat);
            //}
            //public static bool operator !=(Cat firstCat, Cat seconCat)
            //{
            //    return !Cat.Equals(firstCat, seconCat);
            //}

            //public override bool Equals(object obj)
            //{
            //    var otherCat = (Cat)obj;
            //    return this.Age == otherCat.Age;

            //}
            ////Destructor
            //~Cat()
            //{
            //}
        }
    }
}
