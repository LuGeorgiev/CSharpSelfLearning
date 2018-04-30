using System;
using System.Collections.Generic;
using System.Text;

namespace P04_P06_BoxGeneric
{
    public class Box<T>
        where T:IComparable<T>
    {
        private List<T> items;

        public Box()
        {
            this.items = new List<T>();
        }

        public IReadOnlyCollection<T> Items
        {
            get
            {
                return this.items;
            }
        }

        public void Add(T item)
        {
            this.items.Add(item);
        }
        public void SwapItems(int firstIndex, int secondIndex)
        {
            T temp = items[firstIndex];

            items[firstIndex] = items[secondIndex];
            items[secondIndex] = temp;
        }

        public int GreaterThan(T compareWith)
        {
            int greaterCount = 0;
            foreach (var item in this.items)
            {
                if (item.CompareTo(compareWith)>0)
                {
                    greaterCount++;
                }
            }
            return greaterCount;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (var item in this.Items)
            {
                sb.AppendLine($"{item.GetType().FullName}: {item}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
