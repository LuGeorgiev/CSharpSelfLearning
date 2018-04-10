using System;
using System.Linq;


    public class InitializeTheTree
    {
        
        static Person person = new Person();

        static void Main()
        {
            //#2 Zero test is not correct and I cannot find teh mistakes 0/100
            // if solved during labs I will be corected
            var input = Console.ReadLine();

            //check if first symbol is digit
            if (48<=input[0]&& input[0]<=57)
            {
                person.Birthday = input;
            }
            else
            {
                person.FullName = input;
            }

            while ((input=Console.ReadLine())!="End")
            {
                bool isParentChildPair = input.IndexOf(" - ") > 0;
                if (isParentChildPair)
                {
                    InitializeParentAndChildProp(input);
                }
                else
                {
                    AddPersonInfo(input);
                }                
            }
            Console.WriteLine(person.ToString());
        }

        private static void AddPersonInfo(string input)
        {
            var nameDatePair = input.Split();
            var name = nameDatePair[0] + " " + nameDatePair[1];
            var birthDate = nameDatePair[2];
            if (person.FullName == name)
            {
                person.Birthday = birthDate;                
            }
            else if (person.Birthday == birthDate)
            {
                person.FullName = name;
            }
            else if (person.Parents.Any(x=>x.FullName==name))
            {
                var parent = person.Parents.FirstOrDefault(x => x.FullName == name);
                parent.Birthday = birthDate;
            }
            else if (person.Parents.Any(x => x.Birthday == birthDate))
            {
                var parent = person.Parents.FirstOrDefault(x => x.Birthday == birthDate);
                parent.FullName = name;
            }
            else if (person.Children.Any(x => x.FullName == name))
            {
                var child = person.Children.FirstOrDefault(x => x.FullName == name);
                child.Birthday = birthDate;
            }
            else if (person.Children.Any(x => x.Birthday == birthDate))
            {
                var child = person.Children.FirstOrDefault(x => x.Birthday == birthDate);
                child.FullName = name;
            }
        }

        private static void InitializeParentAndChildProp(string input)
        {
            var parentChildPair = input.Split(" - ");

            //check if first symbol is digit
            bool isParentInfoYear = 48 <= parentChildPair[0][0] && parentChildPair[0][0] <= 57;
            bool isChildInfoYear = 48 <= parentChildPair[1][0] && parentChildPair[1][0] <= 57;
            if (isParentInfoYear)
            {
                person.Parents.Add(new Parent { Birthday = parentChildPair[0]});
            }
            else
            {
                person.Parents.Add(new Parent { FullName = parentChildPair[0] });
            }

            if (isChildInfoYear)
            {
                person.Children.Add(new Child { Birthday = parentChildPair[1] });
            }
            else
            {
                person.Children.Add(new Child { FullName = parentChildPair[1] });
            }

        }

        //to DELETE
        private static bool FindIfParentIsExisting(bool isParentInfoYear, string parentInfo)
        {
            if (isParentInfoYear)
            {
                //look for year in parents
                return person.Parents.Any(x => x.Birthday == parentInfo);

            }
            else
            {
                return person.Parents.Any(x => x.FullName == parentInfo);
            }
        }
    }

