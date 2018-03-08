using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FromFirstEx
{
    class FromFirst
    {
        static void PrintOddLines(string file)
        {
            var encoding = Encoding.GetEncoding(1251);
            Console.OutputEncoding = encoding;

            if (File.Exists(file))
            {
            var streamFile = new StreamReader(file, encoding);
                try
                {
                    int lineCount = 1;
                    var line = streamFile.ReadLine();
                    Console.WriteLine(line);

                    while (line!=null)
                    {
                        lineCount++;
                        line = streamFile.ReadLine();
                        if (lineCount%2==1)
                            Console.WriteLine(line);
                    }
                    streamFile.Close();
                }
                catch (IOException io)
                {
                    Console.WriteLine("File was not correctly read: {0}", io.Message);                    
                }
            }
            else
            {
                Console.WriteLine("File do not exist or path is not correct");
            }
        }

        static void AppendFiles(string first, string second)
        {
            var encoding = Encoding.UTF8;
            Console.OutputEncoding = encoding;
            var outputFile = @"..\..\Result.txt";

            using (var stream = new StreamReader(first,encoding))
            {
                using (var writer = new StreamWriter(outputFile,false,encoding))
                {
                    var line = stream.ReadLine();
                    writer.WriteLine(line);                    
                    while (line!=null)
                    {
                        line = stream.ReadLine();
                        if(line!=null)
                            writer.WriteLine(line);
                    }
                }
            }

            using (var stream = new StreamReader(second, encoding))
            {
                using (var writer = new StreamWriter(outputFile, true, encoding))
                {
                    var line = stream.ReadLine();
                    writer.WriteLine(line);
                    while (line != null)
                    {
                        line = stream.ReadLine();
                        if (line != null)
                            writer.WriteLine(line);
                    }
                }
            }

        }

        static void AddLineNumbers(string file)
        {
            var encoding = Encoding.UTF8;
            Console.OutputEncoding = encoding;
            var outputFile = @"..\..\WithLineNumbers.txt";
            var lineCount = 1;

            using (var read = new StreamReader(file, encoding))
            {
                using (var write = new StreamWriter(outputFile,false,encoding))
                {
                    var line = lineCount +" "+ read.ReadLine();
                    write.WriteLine(line);
                    while (read.ReadLine()!= null)
                    {
                        lineCount++;
                        line = lineCount +" "+ read.ReadLine();
                        write.WriteLine(line);                        
                    }
                }
            }

        }

        static void PrintNumberEqualAndDiff(string firstFile, string secondFile)
        {
            var encoding = Encoding.UTF8;
            Console.OutputEncoding = encoding;
            int equal = 0;
            int different = 0;

            using (var first = new StreamReader(firstFile,encoding))
            {
                using (var second = new StreamReader(secondFile,encoding))
                {
                    string lineOne = first.ReadLine();
                    string lineTwo = second.ReadLine();
                    if (lineOne == lineTwo)
                        equal++;
                    else
                        different++;

                    while (lineTwo!=null&&lineOne!=null)
                    {
                        lineOne = first.ReadLine();
                        lineTwo = second.ReadLine();
                        if (lineOne == lineTwo)
                            equal++;
                        else
                            different++;
                    }
                }
            }

            Console.WriteLine("There are {0} equal lines and {1} different",equal,different);
        }

        static void Main()
        {
            string file = @"..\..\WinterIsComing.txt";
            string secondFile = @"..\..\AddMe.txt";
            string firstCopare = @"..\..\Result.txt";
            string secondCopare = @"..\..\Resumlt.txt";

            //PrintOddLines(file);                        // First Excercise
            //AppendFiles(file, secondFile);              //Second Excercise
            //AddLineNumbers(file);                       //Third Excercise
            PrintNumberEqualAndDiff(firstCopare, secondCopare);

        }
    }
}
