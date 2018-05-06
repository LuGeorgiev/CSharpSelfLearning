using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Text;

namespace LabSpy
{
    public class Tracker
    {
        public void PrintMethodsByAuthor()
        {
            var type = typeof(StartSpy);
            var methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);

            foreach (var method in methods)
            {
                if (method.CustomAttributes.Any(n=>n.AttributeType==typeof(SoftUniAttribute)))
                {
                    var attrs = method.GetCustomAttributes(false);
                    foreach (SoftUniAttribute attr in attrs)
                    {
                        Console.Write($"{method.Name} is written by {attr.Name}");
                        if (attr.Year ==0)
                        {
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine($" in Year: {attr.Year}");
                        }
                    }
                }
            }
        }
    }
}
