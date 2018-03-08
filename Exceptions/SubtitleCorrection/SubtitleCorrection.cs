using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubtitleCorrection
{
    class SubtitleCorrection
    {
        const double COEFFICIENT = 1.05;
        const int ADDITION = 5000;
        const string INPUT_FILE = @"..\..\GORA.txt";
        const string OUTPUT_FILE = @"..\..\fixdGORA.txt";

        static void Main()
        {
            try
            {
                var encoding = Encoding.GetEncoding(1251);
                var streamReader = new StreamReader(INPUT_FILE,encoding);
                var streamWriter = new StreamWriter(OUTPUT_FILE,true,encoding);

                using (streamReader)
                {
                    using (streamWriter)
                    {
                        string line;
                        while ((line=streamReader.ReadLine())!=null)
                        {
                            streamWriter.WriteLine(FixLine(line));
                        }
                    }

                }
            }
            catch (IOException exc)
            {

                Console.WriteLine("Error: {0}", exc.Message); 
            }

        }

        static string FixLine(string line)
        {
            int bracketFromIndex = line.IndexOf('}');
            string fromTime = line.Substring(1, bracketFromIndex - 1);
            int newFromTime = (int)(Convert.ToInt32(fromTime) * COEFFICIENT + ADDITION);

            int bracketToIndex = line.IndexOf('}', bracketFromIndex + 1);
            string toTime = line.Substring(bracketFromIndex + 2, bracketToIndex - bracketFromIndex - 2);
            int newToTime = (int)(Convert.ToInt32(toTime) * COEFFICIENT + ADDITION);

            string fixedLine = "{" + newFromTime + "}" + "{" + newToTime + "}" + line.Substring(bracketToIndex + 1);

            return fixedLine;
        }
    }
}
