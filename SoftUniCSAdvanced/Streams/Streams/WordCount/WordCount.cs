using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WordCount
{
    class WordCount
    {
        static void Main(string[] args)
        {
            var wordCount = new Dictionary<string, int>();
            var reader = new StreamReader("../../../text.txt");

            using (reader)
            {
                string line = "";
                while ((line=reader.ReadLine())!=null)
                {
                    var wordsInLine = line
                        .Split(new[] { ' ', '.', ',', '!', '?', '-', ':', ';' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(x => x.ToLower())
                        .ToList();
                    foreach (var word in wordsInLine)
                    {
                        if (!wordCount.ContainsKey(word))
                        {
                            wordCount[word] = 0;
                        }
                        wordCount[word]++;
                    }
                }
            }

            var sortedWords = wordCount
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .ToList();

            var writer = new StreamWriter("../../../result.txt");
            using (writer)
            {
                foreach (var kvp in sortedWords)
                {
                    writer.WriteLine($"{kvp.Key} - {kvp.Value}");
                }
            }
        }
    }
}
