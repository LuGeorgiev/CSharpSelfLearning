using System;

namespace DateModifier
{
    public class Start
    {
        static void Main(string[] args)
        {
            var initialDate = Console.ReadLine();
            var endDate = Console.ReadLine();

            var timeSpan = new DateModifier(initialDate, endDate);
            Console.WriteLine(timeSpan.DateDifference);
        }
    }
}
