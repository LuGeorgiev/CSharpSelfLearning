using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_1
{
    public class TestReflection:IDerivedInterface
    {
        public static string publicStaticString; 
        private static string privateStaticString;

        private string privateInstance;
        public string publicInstance;

        public TestReflection()
        {

        }
        public TestReflection(int number)
        {

        }
    }

    interface IBAseInteface
    {
    }

    interface IDerivedInterface
    {
    }
}
