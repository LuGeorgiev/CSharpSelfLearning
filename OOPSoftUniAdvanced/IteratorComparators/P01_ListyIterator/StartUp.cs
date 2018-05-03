using System;
using System.Linq;

namespace P01_ListyIterator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var creationInput = Console.ReadLine().Split().Skip(1).ToArray();
            var listyIterrator = new ListyItaerator<string>(creationInput);

            var input = "";
            while ((input=Console.ReadLine())!="END")
            {
                if (input == "HasNext")
                {
                    Console.WriteLine(listyIterrator.HasNext());
                }
                else if (input == "Print")
                {
                    try
                    {
                        listyIterrator.Print();
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (input == "Move")
                {
                    Console.WriteLine(listyIterrator.MoveTo());                    
                }
                else if (input == "PrintAll")
                {
                    listyIterrator.PrintAll();
                }

            }
        }
    }
}
