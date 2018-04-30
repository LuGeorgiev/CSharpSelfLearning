using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P07_P09_CustomList
{
    public class CustomList<T>:ICustomList<T>
        where T:IComparable<T>
    {
        private IList<T> items;

        public CustomList()
        {
            this.items = new List<T>();
        }
        
        public IReadOnlyCollection<T> Items
        {
            get
            {
                return (IReadOnlyCollection<T>)this.items;
            }
        }

        public void Add(T item)
        {
            this.items.Add(item);
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            T temp = items[firstIndex];

            items[firstIndex] = items[secondIndex];
            items[secondIndex] = temp;
        }

        public int CountGreaterThan(T compareWith)
        {
            int greaterCount = 0;
            foreach (var item in this.Items)
            {
                if (item.CompareTo(compareWith) > 0)
                {
                    greaterCount++;
                }
            }
            return greaterCount;
        }

        public T Remove(int index)
        {
            T result = this.items[index];
            this.items.RemoveAt(index);

            return result;
        }

        public bool Contains(T element)
        {
            var isContained = false;

            foreach (var item in this.Items)
            {
                if (item.Equals(element))
                {
                    isContained = true;
                    break;
                }
            }
            return isContained;
        }

        public T Max()
        {
            T maximum = this.items[0];
            foreach (var item in this.Items)
            {
                if (item.CompareTo(maximum)>0)
                {
                    maximum = item;
                }
            }
            return maximum;
        }
        public T Min()
        {
            T maximum = this.items[0];
            foreach (var item in this.Items)
            {
                if (item.CompareTo(maximum) < 0)
                {
                    maximum = item;
                }
            }
            return maximum;
        }

        public void Print()
        {
            foreach (var item in this.Items)
            {
                Console.WriteLine(item);
            }
        }
    }
}
