using System;
using System.Collections.Generic;
using System.Text;

namespace P02_BookShop
{
    public class Book
    {
        private string title;
        private string author;
        private decimal price;

        public virtual decimal Price
        {
            get { return price; }
            protected set
            {
                if (value<0)
                {
                    throw new ArgumentException("Price not valid!");
                }
                price = value;
            }
        }
        public string Author 
        {
            get { return author; }
            protected set
            {
                bool isNameValid = ValidateAuthorName(value);
                if (isNameValid==false)
                {
                    throw new ArgumentException("Author not valid!");
                }
                author = value;
            }
        }
        public string Title
        {
            get { return title; }
            protected set
            {
                if (value.Length<3)
                {
                    throw new ArgumentException("Title not valid!");
                }
                title = value;
            }
        }

        public Book(string author, string title, decimal price)
        {
            this.Author = author;
            this.Title = title;
            this.Price = price;
        }
        public override string ToString()
        {
            var resultBuilder = new StringBuilder();
            resultBuilder.AppendLine($"Type: {this.GetType().Name}")
                .AppendLine($"Title: {this.Title}")
                .AppendLine($"Author: {this.Author}")
                .AppendLine($"Price: {this.Price:f2}");

            string result = resultBuilder.ToString().TrimEnd();
            return result;
        }

        private bool ValidateAuthorName(string value)
        {
            bool isValid = true;

            var names = value.Split();
            if (names.Length==2)
            {
                char firstOfSecondName = names[1][0];
                if (48<=firstOfSecondName&&firstOfSecondName<=57)
                {
                    isValid = false;
                }                
            }         
            
            return isValid;
        }
    }
}
