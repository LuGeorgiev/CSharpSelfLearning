using System;
using System.Linq;


namespace LINQ
{
    class GoMF
    {
        static void Main()
        {
            var usualSuspect = new string[] { "pffgesho", "gsho", "tosho", "rexi", "kura mi Qnko","stamat" };

            //var shoshovci = from suspect in usualSuspect
            //                where suspect.EndsWith("sho")||suspect.Contains("rex")
            //                orderby suspect.Length
            //                select $"Usual suspect called: {suspect}";//SElect Казва се проектиране

            var shoshovci = usualSuspect
                .Where(names => names.EndsWith("sho"))
                .OrderBy(suspect => suspect.Length)
                .ThenBy(suspect => suspect)
                .Select(suspect => "Cyber criminal " + suspect);

            // Console.WriteLine(string.Join("\r\n",shoshovci));

            var numbers = new int[] { 1, 2, 4, 6, 8, 87, 5, 43, 2 };
            var sum = numbers.Sum(x=>x&1); //Suma ot nai-mladshite bitova (kolko nechetni chisla ima v masiva)
            sum = numbers.Select(x => x & 1).Sum(); // ekvivalentni sa poslednite dve
            Console.WriteLine(sum);

            var sequence = Enumerable.Range(1, 12).ToArray();
            Console.WriteLine(String.Join(", ",sequence));

            //var nums = Enumerable.Range(0, 5).Select(x => int.Parse(Console.ReadLine())).ToArray();
            //Console.WriteLine(String.Join(", ", nums));

            var random = new Random();
            var nums = Enumerable.Range(0, 5).Select(x =>random.Next(0,100));// bez ToList, Array i.n. cislata sa razlichni vinagi
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(string.Join(", ",nums));
            }
        }
    }
}
