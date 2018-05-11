using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P02_ListIterator
{
    public class ListyItaerator<T> : IEnumerable<T>, IListyItaerator<T>
    {
        private List<T> elements;
        private int index;


        public ListyItaerator(params T[] elements)
        {
            if (elements==null)
            {
                throw new ArgumentNullException();
            }
            this.elements = elements.ToList();
            this.index = 0;
        }

        public IReadOnlyCollection<T> Elements
        {
            get
            {
                return (IReadOnlyCollection<T>)this.elements;
            }
        }

        public int Index
        {
            get
            {
                return this.index;
            }
        }

        public bool MoveTo()
        {
            this.index++;
            return this.index < elements?.Count;
        }

        public void Print()
        {
            if (this.index >= elements?.Count)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }
            Console.WriteLine(elements[index]);
        }

        public bool HasNext()
        {
            var nextIndex = this.index + 1;
            return nextIndex < elements?.Count;
        }

        public void PrintAll()
        {
            foreach (var element in this.elements)
            {
                Console.Write(element + " ");
            }
            Console.WriteLine();
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < elements.Count; i++)
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
