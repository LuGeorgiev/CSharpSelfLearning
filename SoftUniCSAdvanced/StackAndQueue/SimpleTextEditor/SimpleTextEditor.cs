using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleTextEditor
{
    class SimpleTextEditor
    {
        static Stack<string> undoCommands = new Stack<string>();
        static Stack<char> stack = new Stack<char>();

        static void Main()
        {
            var commandsNumber = int.Parse(Console.ReadLine());
            for (int i = 0; i < commandsNumber; i++)
            {
                var nextComand = Console.ReadLine();
                if (nextComand.StartsWith("1"))
                {
                    AddInStack(nextComand);
                }
                else if (nextComand.StartsWith("2"))
                {
                    EreseFromStack(nextComand);
                }
                else if (nextComand.StartsWith("3"))
                {
                    PrintFromStack(nextComand);
                }
                else if (nextComand.StartsWith("4"))
                {
                    UndoLastEresaOrPrint();
                }
            }
        }

        private static void UndoLastEresaOrPrint()
        {
            var commandToUndo = undoCommands.Pop();
            if (commandToUndo.StartsWith("1"))
            {
                var textToAdd = commandToUndo.Split(' ').Last();
                for (int i = 0; i < textToAdd.Length; i++)
                {
                    stack.Push(textToAdd[i]);
                }
            }
            else if (commandToUndo.StartsWith("2"))
            {
                var symbolsToEraseQTY = int.Parse(commandToUndo
                .Split(' ')
                .Last());
                for (int i = 0; i < symbolsToEraseQTY; i++)
                {
                    stack.Pop();
                }
            }
        }

        private static void PrintFromStack(string nextComand)
        {
            var temporaryPoppedFromStack = new Stack<char>();

            int numberToPrint = int.Parse(nextComand
                .Split(' ')
                .Last());
            while (numberToPrint<stack.Count)
            {
                temporaryPoppedFromStack.Push(stack.Pop());
            }

            Console.WriteLine(stack.Peek().ToString());

            while (temporaryPoppedFromStack.Count>0)
            {
                stack.Push(temporaryPoppedFromStack.Pop());
            }
        }

        private static void EreseFromStack(string nextComand)
        {
            var symbolsToEraseQTY = int.Parse( nextComand
                .Split(' ')
                .Last());
            string erasedSymbols = "";
            for (int i = 0; i < symbolsToEraseQTY; i++)
            {
                var lastErased = stack.Pop();
                erasedSymbols = lastErased + erasedSymbols;
            }

            string undoCommand = "1 " + erasedSymbols;
            undoCommands.Push(undoCommand);
        }

        private static void AddInStack(string nextComand)
        {
            var textToAdd = nextComand.Split(' ').Last();
            for (int i = 0; i < textToAdd.Length; i++)
            {
                stack.Push(textToAdd[i]);
            }

            var undoCommand = "2 " + textToAdd.Length.ToString();
            undoCommands.Push(undoCommand);
        }
    }
}
