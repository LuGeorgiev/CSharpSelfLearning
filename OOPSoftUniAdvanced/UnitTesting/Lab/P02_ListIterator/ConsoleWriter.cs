﻿using System;
using System.Collections.Generic;
using System.Text;

namespace P02_ListIterator
{
    public class ConsoleWriter : IWriter
    {
        public void Write(string text)
        {
            Console.Write(text);
        }

        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }
    }
}
