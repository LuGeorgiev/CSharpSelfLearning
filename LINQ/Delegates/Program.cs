using System;
using System.Collections.Generic;


namespace Delegates
{
    delegate void PrintStuff(string stuff);

    delegate bool  Predicate<T> (T value);


    class Program
    {
        static IEnumerable<T> Filter<T>(IEnumerable<T> numbers, Predicate<T> predicate)
        {
            var list = new List<T>();
            foreach (var n in numbers)
            {
                if (predicate(n))
                {
                    list.Add(n);
                }
            }
            return list;
        }


        static void PrintHello(string name)
        {
            Console.WriteLine($"Hello from {name}");
        }

        static void Print2(string text)
        {
            Console.WriteLine($"----------{text}--------");
        }

        static void PrintGren(string text)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(text);
        }


        static void Main()
        {
            //PrintStuff print = PrintHello;
            //print("pesho");
            //PrintStuff lint = PrintGren;
            //lint("pesho");

            var numbers = new int[] { 1,9, 2, 3, 6, 5, 45, 7, 654, 23, 3, 6, 9, 70 };

            var greater = Filter(numbers, delegate (int value)
            {
                return value > 5;
            });

            var even = Filter(numbers, delegate (int value)
            {
                return value % 2==0;
            });

            var words = new string[] { "gosho", "pesho", "ibane", "petkan", "ivo" };

            var showWords = Filter(words, delegate (string w)
            {
                return w.Length <= 4;
            });
            foreach (var word in showWords)
            {
                Console.WriteLine(word);
            }
            
        }
    }
}
