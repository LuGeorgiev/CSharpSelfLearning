using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P07_P09_CustomList
{
    public class CustomList<T>:IEnumerable<T>
        where T : IComparable<T>
    {
        private T[] data;

        public CustomList()
        {
            this.data = new T[4];
            this.Count = 0;
        }
        public CustomList(int initialSize)
        {
            this.data = new T[initialSize];
            this.Count = 0;
        }

        public bool IsEmpty => this.Count == 0;

        public int InnerArraySize => this.data.Length;

        public int Count { get; private set; }

        //This way we put index on our collection
        public T this[int index]
        {
            get
            {
                return this.data[index];
            }
            private set
            {
                this.data[index] = value;
            }
        }

        public void Add(T item)
        {

            this.Count++;
            if (this.Count > this.InnerArraySize)
            {
                T[] newData = new T[this.InnerArraySize * 2];
                Array.Copy(this.data, newData, this.InnerArraySize);
                this.data = newData;
            }
            this.data[this.Count - 1] = item;
        }

        public T Remove(int index)
        {
            this.ValidateIndex(index);
            T element = this.data[index];
            this.Count--;

            for (int i = index; i < this.Count; i++)
            {
                this.data[i] = this.data[i + 1];
            }
            this.data[this.Count] = default(T);

            if (this.Count < this.InnerArraySize / 3)
            {
                T[] newData = new T[this.InnerArraySize / 2];
                Array.Copy(this.data, newData, this.Count);
                this.data = newData;
            }
            return element;
        }

        public bool Contains(T element)
        {
            var isContained = false;

            for (int i = 0; i < this.Count; i++)
            {
                if (data[i].Equals(element))
                {
                    isContained = true;
                    break;
                }
            }
            return isContained;
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            this.ValidateIndex(firstIndex);
            this.ValidateIndex(secondIndex);
            
            T temp = data[firstIndex];

            data[firstIndex] = data[secondIndex];
            data[secondIndex] = temp;
        }

        public int CountGreaterThan(T compareWith)
        {
            int greaterCount = 0;

            for (int i = 0; i < this.Count; i++)
            {
                if (data[i].CompareTo(compareWith) > 0)
                {
                    greaterCount++;
                }
            }
            return greaterCount;
        }

        public T Max()
        {
            T maximum = this.data[0];
            for (int i=1; i<this.Count;i++)
            {
                if (data[i].CompareTo(maximum)>0)
                {
                    maximum = data[i];
                }
            }
            return maximum;
        }
        public void Sort(IComparer<T> comparer= null)
        {
            Array.Sort(this.data,0,this.Count, comparer);
        }

        public T Min()
        {
            T maximum = this.data[0];
            for (int i = 1; i < this.Count; i++)
            {
                if (data[i].CompareTo(maximum) < 0)
                {
                    maximum = data[i];
                }
            }
            return maximum;
        }

        public void Print()
        {
            for (int i = 0; i < this.Count; i++)
            {
                Console.WriteLine(data[i]);

            }           
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return this.data[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public void ValidateIndex(int index)
        {
            if (index<0||this.Count< index)
            {
                throw new IndexOutOfRangeException();
            }
        }
    }
}
