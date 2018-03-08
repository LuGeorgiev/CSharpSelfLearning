using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkingDays
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime today = new DateTime();
            DateTime endDate = new DateTime();
            int workDayCounter = 0;

            DateTime[] notWorking = 
                {
                  new DateTime(2017,12,23),
                  new DateTime(2017,12,24),
                  new DateTime(2017,12,25),
                  new DateTime(2018,1,1),
                  new DateTime(2018,3,5),
                  new DateTime(2018,4,6),
                  new DateTime(2018,5,1),
                  new DateTime(2018,5,7),
                  new DateTime(2018,5,24),
                  new DateTime(2018,9,6),
                  new DateTime(2018,9,24),
                  new DateTime(2018,12,23),
                  new DateTime(2018,12,23),
                  new DateTime(2018,12,24),
                  new DateTime(2018,12,25)
                };           

            today = DateTime.Today;            
            endDate = DateTime.Parse(Console.ReadLine());         
                   

            if (DateTime.Compare(today, endDate)==1|| DateTime.Compare(today, endDate) == 0)
            {
                Console.WriteLine("Please enter a valid period");
            }
            else
            {
                do
                {
                    today = today.AddDays(1);
                    string weekday = today.DayOfWeek.ToString();

                    if (weekday!="Saturday"&& weekday != "Sunday")                           // detects if it is workday
                    {
                        workDayCounter++;
                        for (int i = 0; i < notWorking.Length; i++)
                        {
                            if (today == notWorking[i])                                      //detects Hollidays
                                workDayCounter--;
                        }
                    }
                    
                } while (today!= endDate);             
                
            }

            Console.WriteLine("There are {0} more working days in period from today to {1:dd/MM/yy}.",workDayCounter,endDate);
        }
    }
}
