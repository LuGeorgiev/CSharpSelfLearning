using System;
using System.IO;
using System.Text;


namespace TextClass
{
    class Stream
    {
        static void Main()
        {
            var encoding = Encoding.Unicode;
            Console.OutputEncoding = encoding;
            var sourceFile = @"..\..\neshto.txt";
            var outputFile = @"..\..\lqto.txt";

            using (StreamReader stream = new StreamReader(sourceFile,encoding))
            {
                using (var writer = new StreamWriter(outputFile,false,encoding))
                {
                    var line = stream.ReadLine();
                    
                    while (line!=null)
                    {
                        line = stream.ReadLine();
                        writer.WriteLine(line);
                        Console.WriteLine(line);
                    }
                }
            }                       
            
        }
    }
}
