using System;
using System.Linq;
using System.Text;


namespace StringExcerciseSix
{
    class FromSix
    {
        public static string ConvertTaggedToUpper(string input)
        {
            StringBuilder output = new StringBuilder();
            int startIndex = 0;
            int first = 0;
            int endIndex = startIndex+1;

            do
            {
                startIndex = input.IndexOf("<upcase>",startIndex);
                endIndex = input.IndexOf("</upcase>",endIndex);
                    if (startIndex>=0&&endIndex>0)
                    {
                    output.Append(input.Substring(first,startIndex-first));
                    output.Append(input.Substring(startIndex+8,endIndex- startIndex-8).ToUpper());
                    }
                first = endIndex + 9;
                startIndex += 1;
                endIndex += 1;
            } while (startIndex>0);

            endIndex = input.LastIndexOf("</upcase>");
            output = output.Append(input.Substring(endIndex + 9));

            return output.ToString();
        }

        static string GetUnicodeString(string s)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in s)
            {
                sb.Append("\\u");
                sb.Append(String.Format("{0:x4}", (int)c));
            }
            return sb.ToString();
        }

        static string CodingWords(string input)
        {
            string result = "";
            for (int i = 0; i < input.Length; i++)
            {
                if (i%2==0)
                {
                    result+=Convert.ToChar(input[i] ^ 'a');
                }
                else
                {
                    result += Convert.ToChar(input[i] ^ 'b');
                }

            }

            return result;
        }

        static void Main()
        {
            //string text = "We all leave in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> it worksss.";
            //Console.WriteLine(ConvertTaggedToUpper(text));                             // Convetr ToUpper tagged string

            //string test = Console.ReadLine();                                 //ADD * to 20 positions
            //if (test.Length<20)            
            //    Console.WriteLine(test.PadRight(20, '*'));

            string toUnicode = Console.ReadLine();                                 // Task 8 and 9 from string to UNICODE sequence and XOR coding
            string backCode="";
            Console.WriteLine(GetUnicodeString(CodingWords(toUnicode)));
            backCode = GetUnicodeString(CodingWords(toUnicode));
            Console.WriteLine(CodingWords(CodingWords(backCode)));
        }
    }
}
