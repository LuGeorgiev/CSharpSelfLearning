using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo
{
    class BoxLab01
    {
        static void Main(string[] args)
        {
            var box = new Box<int>(); // aftre initialization ONLY int can be used

            box.Add(2);
            box.Add(221);
            box.Add(1);
            box.Add(22);
            box.Add(23);
        }

    }

    public class Box<T>
    {
        private List<T> items;

        public Box()
        {
            this.items = new List<T>();
        }

        public void Add(T item)
        {
            this.items.Add(item);
        }

        public T Remove()
        {
            var element = this.items.Last();
            this.items.RemoveAt(this.items.Count - 1);

            return element;
        }

        public int Count() => this.items.Count;
    }
}
