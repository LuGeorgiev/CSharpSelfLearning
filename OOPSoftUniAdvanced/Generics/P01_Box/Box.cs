using System;
using System.Collections.Generic;
using System.Text;

namespace P01_Box
{
    public class Box<T>
    {
        private T item;

        public Box(T item)
        {
            this.item = item;
        }

        //public void Add(T item)
        //{
        //    this.items.Add(item);
        //}

        public override string ToString()
        {
            return $"{this.item.GetType().FullName}: {this.item.ToString()}";
        }
    }
}
