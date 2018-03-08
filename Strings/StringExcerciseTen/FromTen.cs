using System;
using System.Collections.Generic;
using System.Text;


namespace StringExcerciseTen
{
    class FromTen
    {
        static void FindSentenceWithWord(string text, string seeked)
        {
            List<string> sentences = new List<string>();
            int indexDot=0, initial = 0;
            int indexSeeked = 0;
            do
            {
                indexDot = text.IndexOf('.', indexDot);
                do
                {
                indexSeeked = text.IndexOf(seeked, indexSeeked);
                    if (!Char.IsLetter(text[indexSeeked - 1]) && !Char.IsLetter(text[indexSeeked + seeked.Length])&& indexSeeked < indexDot)
                        break;                    
                    
                        indexSeeked++;
                } while (indexSeeked<indexDot&&!(indexSeeked==-1));

                if (indexSeeked < indexDot)
                    sentences.Add(text.Substring(initial,indexDot-initial+1).Trim());
                
                indexDot++;
                initial = indexDot;
                indexSeeked = indexDot;
            } while (indexDot>0&&indexDot<text.Length-1);

            foreach (var sentence in sentences)
            {
                Console.WriteLine(sentence);
            }            
        }

        static string ReplaceKeyWords(string input, string keys)
        {
            StringBuilder result = new StringBuilder(input);
            string[] keyWords = keys.Split(new char[] { ',', '.', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var keyWord in keyWords)
            {
                string substitute = new string('*', keyWord.Length);
                result.Replace(keyWord, substitute);
            }

            return result.ToString();
        }

        static string[] ExtractProtocolServResource(string inputUrl)
        {
            string[] internetAddress = new string[3];
            string[] separators = { "://", "/" };
            int index = 0, start=0;

            index = inputUrl.IndexOf("://");
            internetAddress[0] =inputUrl.Substring(0,index);
            index += 3;
            start = index;

            index = inputUrl.IndexOf("/",start);
            internetAddress[1] = inputUrl.Substring(0, index-start);
            internetAddress[2] = inputUrl.Substring(index);

            return internetAddress;
        }

        static string ReversWordsKeepPunctuation(string sentence)
        {
            StringBuilder words = new StringBuilder();
            char[] parameters = { ',', ' ', '!', '.', '?', ':', '-', '"' };
            string[] spaceSeparate = sentence.Split();
            string[] onlyWords = sentence.Split(parameters, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < spaceSeparate.Length; i++)
            {
                Char[] lettresInWord = spaceSeparate[i].ToCharArray();

                if (!Char.IsLetter(lettresInWord[0]))
                {
                    switch (lettresInWord[0])
                    { 
                    case '.': words.Append('.'); break;
                    case '?': words.Append('?'); break;
                    case '!': words.Append('!'); break;
                    case ',': words.Append(','); break;
                    case '"': words.Append('"'); break;
                    case ':': words.Append(':'); break;
                    case '-': words.Append('-'); break;
                        default:
                        break;
                    }

                    if (Char.IsLetter(lettresInWord[1]))
                    {
                        words.Append(onlyWords[onlyWords.Length - 1 - i]);
                    }
                }
                else if (Char.IsLetter(lettresInWord[0]))
                {
                    words.Append(onlyWords[onlyWords.Length-1-i]);
                }

                if (!Char.IsLetter(lettresInWord[lettresInWord.Length-1]))
                {
                    switch (lettresInWord[lettresInWord.Length - 1])
                    {
                        case '.': words.Append('.'); break;
                        case '?': words.Append('?'); break;
                        case '!': words.Append('!'); break;
                        case ',': words.Append(','); break;
                        case '"': words.Append('"'); break;
                        case ':': words.Append(':'); break;
                        case '-': words.Append('-'); break;
                        default:
                            break;
                    }

                    if (!Char.IsLetter(lettresInWord[lettresInWord.Length - 2]))
                    {
                        switch (lettresInWord[lettresInWord.Length - 2])
                        {
                            case '.': words.Append('.'); break;
                            case '?': words.Append('?'); break;
                            case '!': words.Append('!'); break;
                            case ',': words.Append(','); break;
                            case '"': words.Append('"'); break;
                            case ':': words.Append(':'); break;
                            case '-': words.Append('-'); break;
                            default:
                                break;
                        }
                    }
                }
                words.Append(' ');
            }
            return words.ToString();
        }

        static void Main()
        {
            string excercise = "We are living in a yellow submarine. We don't have anything else. " +
                "Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days. ";
            // FindSentenceWithWord(excercise, "in");

            string text = "Microsoft announced its next generation C# compiler today. It uses advanced parses and special optimization for the Microsoft CLR.";
            string restrictedWords = "C#,CLR, Microsoft";
            //Console.WriteLine(ReplaceKeyWords(text, restrictedWords)); 

            string url = "http://www.dev.bg.org/forum/index.php";
            string[] addressMorph = ExtractProtocolServResource(url);
            //Console.WriteLine("Protocol is: {0}\nserver is: {1}\nResource is: {2}", addressMorph[0],addressMorph[1], addressMorph[2]);

            string statement = "\"C# is not C++ and PHP is not Delphie.\"";      
            Console.WriteLine(ReversWordsKeepPunctuation(statement));

        }
    }
}
