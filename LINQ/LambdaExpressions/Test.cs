using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LambdaExpressions
{
    class Test
    {
        static void Main(string[] args)
        {
            var numbers = new int[] { 1, 10, -7, -5, 8, 33 };
            Func<int, int, int> sum = (a, b) => a + b;
            Func<string, int> pase = int.Parse;
            //var odd = numbers.Where((value, index)=>index%2==1).ToList();
            //Console.WriteLine(string.Join(",", odd));

            //var sumOfNumbers = 0;
            //foreach (var n in numbers)
            //{
            //    sumOfNumbers = sum(sumOfNumbers, n);
            //}
            //Console.WriteLine(sumOfNumbers);   


            Action<string> saveToFile = text => File.AppendAllText("./Gosho.txt",text+"\r\n");

            //var words = new string[] { "kaun", "C#", "javascript", "sdg" };
            //foreach (var w in words)
            //{
            //    saveToFile(w);
            //}

            //Second way with List of strings
            var words = new List<string> { "kaun", "C#", "javascript", "sdg" };
            words.ForEach(saveToFile);

           
        }
    }
}
