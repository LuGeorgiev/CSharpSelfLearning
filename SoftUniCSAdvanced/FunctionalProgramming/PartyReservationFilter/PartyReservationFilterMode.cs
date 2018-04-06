using System;
using System.Collections.Generic;
using System.Linq;

namespace PartyReservationFilter
{
    class PartyReservationFilterMode
    {
        static void Main(string[] args)
        {
            var initialPartyList = Console.ReadLine().Split().ToList();
            
            var filters = new HashSet<string>();
            var input = "";
            while ((input=Console.ReadLine())!= "Print")
            {                
                if (input.StartsWith("Add filter"))
                {
                    //add filter
                    filters.Add(input);
                }
                else
                {
                    //remove filter if already have same
                    input = input.Replace("Remove","Add");
                    filters.Remove(input);
                }                
            }
            foreach (var filter in filters)
            {
                var filterParts = filter.Split(';').ToList();                
                string filterCondition = filterParts[1];
                string filterArgument = filterParts[2];
                if (filterCondition == "Starts with")
                {
                     PartyFiltration( initialPartyList, x => x.StartsWith(filterArgument));
                    
                }
                else if (filterCondition == "Ends with")
                {
                     PartyFiltration( initialPartyList, x => x.EndsWith(filterArgument));
                }
                else if (filterCondition == "Length")
                {
                     PartyFiltration( initialPartyList, x => x.Length == int.Parse(filterArgument));
                }
                else if (filterCondition == "Contains")
                {
                     PartyFiltration( initialPartyList, x => x.Contains(filterArgument));
                }
            }

            Console.WriteLine(string.Join(" ",initialPartyList));
        }

        private static void PartyFiltration( List<string> initialPartyList, Func<string, bool> condition)
        {
            for(int i=initialPartyList.Count-1;i>=0;i--)
            {
                if (condition(initialPartyList[i]))
                {
                    initialPartyList.RemoveAt(i);
                }
            }
        }
    }
}
