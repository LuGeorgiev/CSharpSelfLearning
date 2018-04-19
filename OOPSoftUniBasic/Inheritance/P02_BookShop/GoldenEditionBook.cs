using System;
using System.Collections.Generic;
using System.Text;

namespace P02_BookShop
{
    public class GoldenEditionBook : Book
    {
        public override decimal Price
        {
            get
            {
                return base.Price * 1.3m;
            }           
        }

        public GoldenEditionBook(string author, string title, decimal price) : base(author, title, price)
        {
        }
    }
}
