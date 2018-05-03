using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P03_Stack
{
    public class CustomStack<T> : IEnumerable<T>
    {
        private List<T> elements;
        private int index;

        public CustomStack()
        {
            this.elements = new List<T>();
            this.index = -1;
        }

        public void Push(params T[] elements)
        {
            this.elements.AddRange(elements);
            this.index += elements.Length;
        }

        public T Pop()
        {
            if (index<0)
            {
                throw new ArgumentException("No elements");
            }
            var result = this.elements[index];
            this.elements.RemoveAt(this.index);
            this.index--;

            return result;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = elements.Count-1; i >= 0; i--)
            {
                yield return elements[i];
            }
            for (int i = elements.Count - 1; i >= 0; i--)
            {
                yield return elements[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
