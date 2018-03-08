using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TenToEnd
{


    class TenToEnd
    {
        public static string ExtractTextFromXML(string line)
        {
            var correctedLine = "";

            int indexStart = 0, indexEnd = 0;
            for (int i = 0; i < line.Length; i++)
            {
                indexStart = line.IndexOf('>', indexStart);
                if (indexStart == -1)
                    break;

                indexEnd = line.IndexOf('<', indexStart);
                if (indexEnd == -1)
                    break;

                if (indexEnd != -1 && indexEnd - indexStart > 1)
                    correctedLine += line.Substring(indexStart + 1, indexEnd - indexStart - 1);

                indexStart = indexEnd + 1;
                i = indexStart;
            }

            return correctedLine;
        }

        public static void ReadWriteTextFile(string fileAddress)
        {
            var encoding = Encoding.UTF8;
            var outputFile = @"..\..\XMLEditResult.xml";

            using (var reader = new StreamReader(fileAddress, encoding))
            {
                using (var writer = new StreamWriter(outputFile, false, encoding))
                {
                    var line = reader.ReadLine();
                    line = ExtractTextFromXML(line);
                    while (line != null)
                    {
                        line = reader.ReadLine();
                        if (line != null)
                            writer.WriteLine(ExtractTextFromXML(line));
                    }
                }
            }
        }

        static int CountWordInText(string word)
        {
            int count = 0;
            var encoding = Encoding.Unicode;
            var fileAddress = @"..\..\text.txt";
            using (var reader = new StreamReader(fileAddress, encoding))
            {
                var line = "";
                while ((line = reader.ReadLine()) != null)
                {
                    int index = 0;
                    line = line.ToLower();
                    while ((index = line.IndexOf(word, index)) != -1)
                    {
                        if (index > 0)
                            count++;
                        index++;
                    }
                }
            }
            return count;
        }

        static Dictionary<string, int> CreatWordsRepetitionDict(string wordsAddress)
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();
            var encoding = Encoding.Unicode;

            using (var reader = new StreamReader(wordsAddress,encoding))
            {
                var line = "";
                while ((line=reader.ReadLine())!=null) //word that will be counted this is the Key
                {
                    int count = CountWordInText(line);
                    dict.Add(line, count);
                }
            }
            return dict;
        }

        static void WriteInFileWordsRepetition(Dictionary<string, int> dictionary)
        {
            var encoding = Encoding.Unicode;
            var outputFile = @"..\..\result.txt";

            using (var writer = new StreamWriter(outputFile,false,encoding))
            {
                var items = from pair in dictionary
                            orderby pair.Value descending
                            select pair;

                foreach (KeyValuePair<string,int> pair in items)
                {
                    writer.WriteLine("{0} се среща: {1} пъти.",pair.Key, pair.Value);
                }

            }
        }

        static void Main()
        {
            //var input = @"..\..\input.xml";
            //ReadWriteTextFile(input);                   //Extract all TAGS from XML

            Console.OutputEncoding = Encoding.Unicode;
            var words = @"..\..\words.txt";
            Dictionary<string, int> wordRepetition = new Dictionary<string, int>(CreatWordsRepetitionDict(words));
            WriteInFileWordsRepetition(wordRepetition);                        
        }
    }
}
