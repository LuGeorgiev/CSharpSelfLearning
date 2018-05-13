using System;
using System.Collections.Generic;
using System.Text;

namespace P02_ListIterator
{
    public interface IWriter
    {
        void Write(string text);
        void WriteLine(string text);
    }
}
