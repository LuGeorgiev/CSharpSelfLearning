using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultitudeRedBlackTree
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeSet<string> bandsIvanchoLikes = new TreeSet<string>(
            new[] {
      "manowar", "blind guardian", "dio",  "grave digger", "kiss",
      "dream theater", "manowar", "megadeth", "dream theater",
      "dio", "judas priest", "manowar", "kreator",
      "blind guardian", "iron maiden", "accept", "dream theater"
            });

            TreeSet<string> bandsMariikaLikes = new TreeSet<string>(
            new[] {
      "iron maiden", "dio", "accept", "manowar", "slayer",
      "megadeth", "dio", "manowar", "running wild", "grave digger",
      "accept", "kiss", "manowar", "iron maiden", "manowar",
      "judas priest", "iced earth", "manowar", "dio",
      "iron maiden", "manowar", "slayer"
            });

            Console.WriteLine("Ivancho likes:");
            Console.WriteLine(GetCommaSepaartedString(bandsIvanchoLikes));
            Console.WriteLine();

            Console.WriteLine("Mariika Likes:");
            Console.WriteLine(GetCommaSepaartedString(bandsMariikaLikes));
            Console.WriteLine();

            TreeSet<string> intersectBands = new TreeSet<string>();
            intersectBands.UnionWith(bandsIvanchoLikes);
            intersectBands.IntersectWith(bandsMariikaLikes);

            Console.WriteLine(string.Format("Does Ivancho likes MAriika?{0}",intersectBands.Count>5?"Yes!":"No!"));

            Console.WriteLine("Because they both like:");
            Console.WriteLine(GetCommaSepaartedString(intersectBands));


        }

        static string GetCommaSepaartedString(IEnumerable<string> items)
        {
            string result = string.Empty;

            int i = 1;
            foreach (var item in items)
            {
                result += item + ", ";
                if (i%3==0)
                {
                    result += Environment.NewLine;
                }
                i++;
            }
            if (result!=string.Empty)
            {
                result = result.TrimEnd(',', ' ', '\r', '\n');
            }
            return result;
        }
    }
}
