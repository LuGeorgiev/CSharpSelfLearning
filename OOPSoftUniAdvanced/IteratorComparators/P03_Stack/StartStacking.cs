using System;
using System.Linq;

namespace P03_Stack
{
    public class StartStacking
    {
        static void Main(string[] args)
        {
            var input = "";
            var myStack = new CustomStack<string>();
            while ((input=Console.ReadLine())!="END")
            {
                if (input.StartsWith("Push"))
                {
                    var pushSequence = input.Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                        .Skip(1)
                        .ToArray();
                    myStack.Push(pushSequence);
                }
                else if (input.StartsWith("Pop"))
                {
                    try
                    {
                        myStack.Pop();
                       
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            foreach (var element in myStack)
            {
                Console.WriteLine(element);
            }          

        }
    }
}
