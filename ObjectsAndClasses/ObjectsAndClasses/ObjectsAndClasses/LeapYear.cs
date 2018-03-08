using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectsAndClasses
{
    class LeapYear
    {

        private static Random rnd=new Random();

        private static DateTime year = new DateTime();

        static void Main()
        {
            int leapOrNO = 2017;
            int daysInFeb;
            daysInFeb = DateTime.DaysInMonth(leapOrNO, 2);

            if (daysInFeb == 29)            
                Console.WriteLine("This year is leap");            
            else
                Console.WriteLine("This year is not leap");               //Leap year or not


            //for (int i = 0; i < 10; i++)                                    // 10 Random numbers
            //{
            //    Console.WriteLine(rnd.Next(99,201));
            //}


            ulong duration;                                                 // Time sinc PC start
            ulong days = 0;
            ulong hours = 0;
            ulong minutes = 0;
            ulong seconds = 0;

            duration = (ulong)Environment.TickCount;
            duration = duration / 1000; // in seconds
            seconds = duration % 60;
            duration /= 60;               //in minutes
            minutes = (duration % 60);
            duration /= 60;             // in hours
            hours = duration % 24;
            days = duration / 24;

            Console.WriteLine("{0} days, {1} hours, {2} minutes and {3} seconds has just passed since pc started",
                days, hours, minutes, seconds);                             // Time sinc PC start

            year = DateTime.Now;                                            // What day is today
            Console.WriteLine(year.DayOfWeek);


        }
    }
}
