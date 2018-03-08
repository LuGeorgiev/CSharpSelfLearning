using System;
using System.Collections.Generic;
using System.Collections;


namespace TreeMapExample
{
    class Startup
    {
        private static readonly string TEXT = "shte uchish li shte bachkash li? Be kvo shte bachkash be? Tui vashto uchene li e?" 
            +"Ia po-hubavo opitai da BACHKASH da se uchish malko! Uchish ne uchish trqbva da bachkash";

        static void Main(string[] args)
        {
            IDictionary<string, int> wordOccurenceMap = GetWordOccurenceMap(TEXT);
            PrintWordOccurenceCount(wordOccurenceMap);
        }

        private static IDictionary<string, int> GetWordOccurenceMap(string text)
        {
            string[] tokens = text.Split(' ', ',','.','?','-','!');
            IDictionary<string, int> words = new SortedDictionary<string, int>();
            foreach (string word in tokens)
            {
                if (string.IsNullOrEmpty(word.Trim()))
                {
                    continue;
                }
                int count;
                if (!words.TryGetValue(word, out count))
                {
                    count = 0;
                }
                words[word] = count + 1;
            }
            return words;
        }

        private static void PrintWordOccurenceCount(IDictionary<string, int> wordOccurenceap)
        {
            foreach (var wordEntry in wordOccurenceap)
            {
                Console.WriteLine("Word '{0}' occurs {1} time(s) in this text", wordEntry.Key, wordEntry.Value);
            }
            Console.WriteLine();
        }
    }
}
