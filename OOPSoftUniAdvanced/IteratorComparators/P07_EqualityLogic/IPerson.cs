using System;
using System.Collections.Generic;
using System.Text;

namespace P07_EqualityLogic
{
    public interface IPerson:IComparable<Person>
    {
        string Name { get; }
        int Age { get; }
    }
}
