using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWfromFirst
{
    public static class ExtensionMethods
    {
        //Implement an extension method Substring(int index, int length) for the class StringBuilder 
        //that returns new StringBuilder and has the same functionality as Substring in the 
        //class String.
        public static void SubString(this StringBuilder builder, int startIndex, int length)
        {
            if (builder.Length<startIndex|| builder.Length<startIndex+length||startIndex<0||length<0)
            {
                throw new IndexOutOfRangeException("Indexes are out of range");
            }
            builder.Remove(startIndex+length,builder.Length-startIndex-length);
            builder.Remove(0, startIndex);
        }


    }
}
