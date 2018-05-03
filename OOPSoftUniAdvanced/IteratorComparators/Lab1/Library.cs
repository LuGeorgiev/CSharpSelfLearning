using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab1
{
    public class Library:IEnumerable<Book>
    {
        //private List<Book> books;

            //Lab2
        private SortedSet<Book> books;

        public Library(params Book[] books)
        {
            //Lab 1:
            //this.books = new List<Book>(books);

            //Lab2: comparator is implemented in Book class here
            //this.books = new SortedSet<Book>(books);

            //Lab 3 with additional comparator. Outer class comparer
            this.books = new SortedSet<Book>(books, new BookComparator());
        }

        public IEnumerator<Book> GetEnumerator()
        {
             return new LibraryIterator(books.ToList());

            //Without using the private class:
            //for (int i = 0; i < books.Count; i++)
            //{
            //    yield return books[i];
            //}
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


        private class LibraryIterator : IEnumerator<Book>
        {

            private IReadOnlyList<Book> books;
            private int index;

            public LibraryIterator(IReadOnlyList<Book> books)
            {
                this.books = books;
                this.index = -1;
            }
            public Book Current => books[this.index];

            object IEnumerator.Current => Current;

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                this.index++;
                return this.index < books?.Count;
            }

            public void Reset()
            {
                this.index = -1;
            }
        }
    }
}
