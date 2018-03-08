using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace FifthExcercise
{
    class FifthEx
    {
        static int[,] ReadMatrixFromText(string file)
        {
            int row = 0;
            int coll = 0;
            char[] toTrim = {' ', ',', '.' };
            List<int> numbers = new List<int>();

            using (var read = new StreamReader(file,Encoding.UTF8))
            {
                var line = read.ReadLine();
                numbers = line.Split(toTrim,StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
                
                coll = numbers.Count;
                row++;
                while (line!=null)
                {
                    line=read.ReadLine();
                    if (line != null)
                    {
                        numbers.AddRange(line.Split(toTrim, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList());
                        row++;
                    }
                }
            }

            int[,] matrix = new int[row,coll];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < coll; j++)
                {
                    matrix[i, j] = numbers[coll*i+j];
                }
            }
            return matrix;
        }

        static int MaxTwoByTwoSum(int[,] matrix)
        {
            int maxSum = int.MinValue;
            for (int i = 0; i < matrix.GetLength(0)-1; i++)
            {
                for (int j = 0; j < matrix.GetLength(1)-1; j++)
                {
                    int sum = matrix[i, j] + matrix[i+1, j] + matrix[i, j+1] + matrix[i+1, j+1];
                    if (sum > maxSum)
                        maxSum = sum;                   
                }

            }

            return maxSum;
        }

        static void SortWords(string input)
        {
            Console.OutputEncoding = Encoding.UTF8;
            List<string> names = new List<string>();
            var outputFile = @"..\..\SortedNames.txt";
            using (var reader =new StreamReader(input, Encoding.UTF8))
            {
                string line = reader.ReadLine();
                names.Add(line);
                while (line!=null)
                {
                    line = reader.ReadLine();
                    if (line != null)
                        names.Add(line);                  
                }            
            }
            names.Sort();
            
            using (var writer = new StreamWriter(outputFile, false, Encoding.UTF8))
            {
                foreach (var name in names)
                {
                    writer.WriteLine(name);
                }
            }

        }

        static void ReplaceStartWithFinish(string file)
        {
            var encoding = Encoding.UTF8;
            var outputFile = @"..\..\ReplacedWords.txt";
            using (var reader = new StreamReader(file,encoding))
            {
                using (var writer = new StreamWriter(outputFile,false,encoding))
                {
                    var line = reader.ReadLine();
                    int indexStart = 0;
                    while (indexStart!=-1)
                        {
                            indexStart = line.IndexOf("start", indexStart);
                            if (indexStart>0&&!Char.IsLetter(line,indexStart-1)&& !Char.IsLetter(line, indexStart + 5))
                            {
                                line = line.Remove(indexStart,5);
                                line = line.Insert(indexStart,"finish");                            
                            }
                            if (indexStart!=-1)                        
                                indexStart++;                                               
                        }
                        writer.WriteLine(line);

                    while (line!=null)
                    {
                        line = reader.ReadLine();
                        if (line!=null)
                        { 
                            indexStart = 0;
                            while (indexStart != -1)
                            {
                                                        
                               indexStart = line.IndexOf("start", indexStart);
                               if (indexStart > 0 && !Char.IsLetter(line, indexStart - 1) && !Char.IsLetter(line, indexStart + 5))
                               {
                                   line = line.Remove(indexStart, 5);
                                   line = line.Insert(indexStart, "finish");
                               }
                               if (indexStart != -1)
                                    indexStart++;                            
                            }
                            writer.WriteLine(line);
                        }
                    }

                }
            }
        }

        static void Main()
        {
            //var input = @"..\..\Matrix.txt";
            //Console.WriteLine(MaxTwoByTwoSum(ReadMatrixFromText(input)));       // Find max 2x2 sum in Matrix

            //var list = @"..\..\Names.txt";
            //SortWords(list);                                                    //Sort names or any kind of words

            var text = @"..\..\StartToReplace.txt";                             //Replace start with finish (only if the whole word is start not a part fo string)
            ReplaceStartWithFinish(text);
        }
    }
}
