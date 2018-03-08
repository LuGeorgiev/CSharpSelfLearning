using System;
using System.Linq;
using System.Text;



namespace StringExcerciseOne
{
       
    class ExcerciseOne
    {
        static string ReverseString(string input)
        {
            StringBuilder reversedInput = new StringBuilder();
            for (int i = input.Length-1; i >= 0; i--)
            {
                reversedInput.Append(input[i]);
            }
            return reversedInput.ToString();
        }           //REVERSE string method
         
        static void CorrectlyPutBrackets(string expression)
        {
            int counter = 0;
            foreach (var position in expression)
            {
                if (position == ')')
                    counter--;
                else if (position == '(')
                    counter++;

                if (counter < 0)
                    break;
            }
            if (counter==0)
            {
                Console.WriteLine("Brackets are correct");
            }
            else
            {
                Console.WriteLine("Brackets are NOT correct");
            }

        }       //Correct brackets

        static int CountSubstring(string input, string seeked)
        {
            int counter = 0;
            int index = 1;
            do
            {
                index = input.ToLower().IndexOf(seeked, index);
                if (index>0)                
                    counter++;
                
                index += 1;

            } while (index>0);

                return counter;
        }

        static void Main()
        {
            string text = "We are living in a yellow submarine. We don't have anything else. " +
                "Inside teh submarine is very tight. So we are drinking all teh day. We will move out of it in 5 days ";
            // Console.WriteLine(ReverseString(text));      //REVERSE string method
            //CorrectlyPutBrackets(text);                   //Correct brackets

            //string[] splitResult=text.Split(new char[] { '*','\\' }, StringSplitOptions.RemoveEmptyEntries);            
            //foreach (var split in splitResult)                                                            // Splitted text with / and remove space
            //    Console.WriteLine(split);

            Console.WriteLine(CountSubstring(text,"in"));
        }
    }
}
