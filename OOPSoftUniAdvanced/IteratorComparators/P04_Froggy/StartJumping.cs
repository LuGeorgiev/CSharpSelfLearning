using System;
using System.Linq;
using System.Text;

namespace P04_Froggy
{
    public class StartJumping
    {
        static void Main()
        {
            var inputStones = Console.ReadLine()
                .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var lake = new Lake<int>(inputStones);
            //Console.WriteLine(string.Join(", ",lake));
            var sb = new StringBuilder();
            foreach (var stone in lake)
            {
                sb.Append(stone + ", ");                
            }
            var length = sb.ToString().Length;
            var result = sb.ToString().Substring(0, length - 2);
            Console.WriteLine(result);
        }
    }
}
