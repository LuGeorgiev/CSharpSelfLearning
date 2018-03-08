using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Text;


namespace From_Fifteen
{
    class Fifteen
    {
        static string Dictionary(string key)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>
            {
                {".net", "platform for applications from Microsoft" },
                {"clr"," managed execution environment for .NET"},
                {"namespace","herarchical organizzation of classes" }

            };

            if (!dict.ContainsKey(key))
            {
                return "not included in this dictionary";
            }
            else
            return dict[key];
        }

        static List<string> ExtractMail(string input)
        {
            List<string> mails = new List<string>();
            List<string> words = input.Split().ToList();
            int indexA = 0, indexDot = 0;
            char[] toTrim = { '.', ' ', '"'};
            foreach (var word in words)
            {
                if (word.Length>6)
                {
                indexA = word.IndexOf('@',1);
                indexDot = word.LastIndexOf('.', word.Length - 2);

                    if (indexA != -1 && indexDot != -1 && indexA < indexDot)
                    {
                         
                        mails.Add(word);
                    }
                }
            }

            for (int i = 0; i < mails.Count; i++)
            {
                mails[i]=mails[i].Trim(toTrim);
            }


            return mails;
        }

        static List<string> ExtractDates(string input)
        {
            List<string> words = input.Split().ToList();
            char[] toTrim = {'.','!',',','?','&','"',';','(',')' };
            for (int i = 0; i < words.Count; i++)
            {
                words[i]=words[i].Trim(toTrim);
            }

            List<string> dates = new List<string>();
            foreach (var word in words)
            {
                if (word.Length>=7)
                {
                    string[] date = word.Split('.');
                    if (date.Length==3)
                    {
                        int num = 0;
                        if (Int32.TryParse(date[0], out num) && num > 0 && num <= 31)
                        {
                            if (Int32.TryParse(date[1], out num) && num > 0 && num <= 12)
                                if (Int32.TryParse(date[2], out num) && num > 1000 && num <= 3000)
                                    dates.Add(word);
                        }
                       
                    }

                }
            }

            return dates;
        }

        static void Main(string[] args)
        {
            //while (true)                                                              //Dictionarry
            //{
            //    string word = Console.ReadLine();
            //    Console.WriteLine("{0} is {1}",word,Dictionary(word.ToLower())); 
            //}

            //string text = "<p>Please visit <a href=\"http://softuni.bg\">our site</a> to choose a software engineering training course. Also visit <a href=\"http://softuni.bg/forum\">our forum</a> to discuss the course. </p> ";
            //string output = text.Replace("<a href=\"", "[URL=").Replace("\">", "] ").Replace("</a>", "[/URL]");
            //Console.WriteLine(output);                                                                  //HREF to URL Replacement

            //string format = "d.M.yyyy";
            //CultureInfo provider = CultureInfo.InvariantCulture;
            //DateTime starData = DateTime.ParseExact(Console.ReadLine(),format, provider);         // Calculate duration in days
            //DateTime endData = DateTime.ParseExact(Console.ReadLine(), format, provider);
            //int days = (endData - starData).Days;
            //Console.WriteLine(days);

            //string format = "d.M.yyyy HH:m:s";
            //CultureInfo provider = CultureInfo.InvariantCulture;
            //DateTime starData = DateTime.ParseExact(Console.ReadLine(), format, provider);          // Prints teh date after 6h and 30 minutes
            //starData= starData.AddHours(6).AddMinutes(30);
            //Console.WriteLine(starData);

            //string letter = "Please contact us by phone (+359 88 59 45 12) or by email at example@abv.bg or at armenian.pop@com.bg. this is not emai: test@test. This is also @gmail.com . neither this: a@a.b.";
            //List < string > mails = ExtractMail(letter);
            //foreach (var mail in mails)
            //{                                                                                     // Extract all e-mail addresses
            //    Console.WriteLine(mail);
            //}

            string dateExtract = "I aws born at 14.06.1980. My sister was born at 3.7.1984. In 5/1999 I graduaded my high school. The law says(see section 7.3.12) that we are allowed to do this (section 7.4.2.9).";
            List<string> datesInText = ExtractDates(dateExtract);
            foreach (var date in datesInText)
            {
                Console.WriteLine(date);
            }


        }
    }
}
