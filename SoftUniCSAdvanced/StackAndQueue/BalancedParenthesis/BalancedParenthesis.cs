using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace BalancedParenthesis
{
    class BalancedParenthesis
    {
        static void Main(string[] args)
        {
            var lineWithParenthesis = Console.ReadLine();

            if (lineWithParenthesis.Length % 2!=0)
            {
                Console.WriteLine("NO");
                Environment.Exit(0);
            }

            if (CheckIfCorrectParenthesis(lineWithParenthesis))
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
            
        }

        public static bool CheckIfCorrectParenthesis(string line)
        {
            //bool isLineCorrect = CheckLine(line);
            //if (!isLineCorrect)
            //{
            //    return false;
            //}
           
            var parenthesisStack = new Stack<char>();         
            for (int i=0; i<line.Length;i++)
            {
                char symbol = line[i];

                if (symbol=='{'|| symbol == '[' || symbol == '(')
                {
                    parenthesisStack.Push(symbol);
                }
                else
                {
                    if (symbol == '}'&& parenthesisStack.Peek()== '{')
                    {
                        parenthesisStack.Pop();
                    }
                    else if (symbol == ']' && parenthesisStack.Peek() == '[')
                    {
                        parenthesisStack.Pop();
                    }
                    else if (symbol == ')' && parenthesisStack.Peek() == '(')
                    {
                        parenthesisStack.Pop();
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        //private static bool CheckLine(string line)
        //{
        //    var pattren = @"^[\[\]\(\)\{\}]+$";
        //    var rgx = new Regex(pattren);
        //    var match = rgx.Match(line);

        //    if (match.Success)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
    }
}
