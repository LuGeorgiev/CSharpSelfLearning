using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FromTwentyOne
{
    class TwentyOne
    {
        static List<string> ExtarctPalidroms(string text)
        {
            char[] charToTrim = {'.',',','-','!',' ','(',')','"','*','_' };
            List<string> wordsInText = text.Split(charToTrim, StringSplitOptions.RemoveEmptyEntries).ToList();
            List<string> polidroms = new List<string>();

            foreach (var word in wordsInText)
            {
                for (int i = 0; i < word.Length/2; i++)
                {
                    if (!(word[i] == word[word.Length - 1 - i]))
                        break;

                    if (i == (word.Length / 2 - 1) && (word[i] == word[word.Length - 1 - i]))
                        polidroms.Add(word);
                    
                }

            }

            return polidroms;
        }

        static void DisplaySymbolOccurency(string text)
        {
            char[] symbolsInText = text.ToCharArray();
            Array.Sort(symbolsInText);
            for (int i = 0; i < symbolsInText.Length; i++)
            {
                int j;

                for (j = symbolsInText.Length-1; j >=i; j--)
                {
                    if (symbolsInText[i]==symbolsInText[j])
                    {
                        Console.WriteLine("Symbol:{0} was met {1} times", symbolsInText[i],(j-i+1));
                        break;
                    }
                }
                i = j;
            }
        }

        static void PrintWordsAlthabetically(string text)
        {
            string[] words = text.Split(',').ToArray();

            Array.Sort(words);
            foreach (var word in words)
            {
                Console.WriteLine(word);
            }
        }

        static void PrintTextWithoutHtML(string[] text)
        {
            foreach (var sentence in text)
            {
                int indexStart = 0, indexEnd = 0;
                for (int i = 0; i < sentence.Length; i++)
                {                    
                    indexStart = sentence.IndexOf('>', indexStart);
                    if (indexStart == -1)
                        break;
                    
                    indexEnd = sentence.IndexOf('<', indexStart);
                    if (indexEnd == -1)
                        break;

                    if (indexEnd !=-1 && indexEnd-indexStart>1)
                        Console.Write(sentence.Substring(indexStart+1,indexEnd-indexStart-1));

                    indexStart = indexEnd + 1;
                    i = indexStart;
                }
                Console.WriteLine();
            }

        }

        static void Main(string[] args)
        {
            //string polidromSearch = "ABBA kur bobina ABba ne iskam da pisha gluposti bobbob loi";
            //List<string> polidroms = ExtarctPalidroms(polidromSearch);                                //Search for Polidroms
            //foreach (var poli in polidroms)            
            //    Console.WriteLine(poli);

            //string word = "asssaaaakosioooAAOaiulp";                              //Display symbol occurency
            //DisplaySymbolOccurency(word);

            //string sentence = "we, will, we will, rock you";
            //PrintWordsAlthabetically(sentence);

            string[] htmlText = { "<html>", "<head><title>News</title></head>", "<body><args href=\"http://softuni.bg\">Software University (SoftUni)</a> provides <b>high-quaity education</b> for software engineers, proffession and job.</p></body>", "</html>" };
            PrintTextWithoutHtML(htmlText);

        }
    }
}
