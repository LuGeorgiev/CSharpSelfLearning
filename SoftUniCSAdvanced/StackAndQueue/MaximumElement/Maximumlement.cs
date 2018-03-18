using System;
using System.Collections.Generic;
using System.Linq;
//Last two TEST not OK
namespace MaximumElement
{
    class Maximumlement
    {
        static void Main()
        {
            var numberOfInputs = byte.Parse(Console.ReadLine());      
            
            var stack = new Stack<int>();
            var maximumValueOfStack = new Stack<int>();
            maximumValueOfStack.Push(int.MinValue);

            for (int i = 0; i < numberOfInputs; i++)
            {
                var input = Console.ReadLine().Trim();
                if (input == "2" && stack.Count > 0)
                {
                    var deletedItem = stack.Pop();
                    //Check if deleted is maximum for maximum value
                    if (deletedItem== maximumValueOfStack.Peek())
                    {
                        maximumValueOfStack.Pop();
                    }
                }
                else if (input == "3" && maximumValueOfStack.Count > 0)
                {
                    Console.WriteLine(maximumValueOfStack.Peek());
                }
                else
                {
                    //add the number
                    var numberToAdd = int.Parse(input
                        .Split(new[] { ' ' },StringSplitOptions.RemoveEmptyEntries)
                        .Last());
                    stack.Push(numberToAdd);
                    if (numberToAdd> maximumValueOfStack.Peek())
                    {                        
                        maximumValueOfStack.Push(numberToAdd);
                    }
                    
                }
            }
        }
    }
}
