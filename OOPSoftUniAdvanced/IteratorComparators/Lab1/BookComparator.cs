using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1
{
    public class BookComparator : IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            var result = x.Title.CompareTo(y.Title);
            if (result ==0)
            {
                result = x.Year.CompareTo(y.Year) * -1;// *-1 in order to be DESCENDING
            }
            return result;
        }
    }
}
