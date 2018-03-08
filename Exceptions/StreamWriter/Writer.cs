using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace StreamWriterClass
{
    class Writer
    {
        static void Main()
        {
            var fileName = @"..\..\neshto.txt";
            var encoding = Encoding.UTF8;
            var appendToFile = true;

            using (var writer = new StreamWriter(fileName, appendToFile, encoding))
            {
                //writer.AutoFlush = true;
                writer.Write(" Zalepi me");
            }                   
            
        }
    }
}
