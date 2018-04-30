using System;

namespace P07_P09_CustomList
{
    class StartUp
    {
        public static void Main(string[] args)
        {
            var custom = new CustomList<string>();
            var input = "";
            while ((input=Console.ReadLine())!="END")
            {
                ParseCommands(input, custom);
            }
            
        }

        private static void ParseCommands(string input, CustomList<string> custom)
        {
            var commandInput = input.Split();
            var action = commandInput[0];
            if (action == "Add")
            {
                var element = commandInput[1];
                custom.Add(element);
            }
            else if (action == "Remove")
            {
                var index = int.Parse(commandInput[1]);
                custom.Remove(index);
            }
            else if (action == "Contains")
            {
                var element = commandInput[1];
                Console.WriteLine(custom.Contains(element));
            }
            else if (action == "Swap")
            {
                var index1 = int.Parse(commandInput[1]);
                var index2 = int.Parse(commandInput[2]);
                custom.Swap(index1, index2);
            }
            else if (action == "Greater")
            {
                var element = commandInput[1];
                Console.WriteLine(custom.CountGreaterThan(element));
            }
            else if (action == "Max")
            {
                Console.WriteLine(custom.Max());
            }
            else if (action == "Min")
            {
                Console.WriteLine(custom.Min());
            }
            else if (action == "Print")
            {
                custom.Print();
            }
            else if (action == "Sort")
            {
                custom.Sort();
            }
        }
    }
}
