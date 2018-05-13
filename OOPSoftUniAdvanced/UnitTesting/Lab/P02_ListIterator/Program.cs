using System;

namespace P02_ListIterator
{
    class Program
    {
        static void Main(string[] args)
        {
            var iter = new ListyItaerator<string>("a", "b", "c");
            var writer = new ConsoleWriter();

            writer.WriteLine(iter.Print());
            
        }
    }
}
