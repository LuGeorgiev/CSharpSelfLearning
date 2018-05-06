using System;
using System.Collections.Generic;
using System.Text;

namespace LabSpy
{
    [AttributeUsage(AttributeTargets.Class|AttributeTargets.Method|AttributeTargets.Property,AllowMultiple =true)]
    public class SoftUniAttribute:Attribute
    {
        public SoftUniAttribute(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }
        public int Year { get; set; }
    }
}
