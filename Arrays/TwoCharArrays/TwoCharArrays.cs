using System;


namespace TwoCharArrays
{
    class TwoCharArrays
    {
        static void Main()
        {
            Console.WriteLine("Enter word A");
            string wordA = Console.ReadLine();
            Console.WriteLine("Enter word B");
            string wordB = Console.ReadLine();

            string temp;

            if (wordA.Length>wordB.Length)
            {
                temp = wordA;
                wordA = wordB;
                wordB = temp;
            }

            for (int i = 0; i < wordA.Length; i++)
            {
                if (wordA[i]<wordB[i])
                {
                    Console.WriteLine("Leksicaly first word is: {0} ", wordA);
                    break;
                }
                if (wordA[i] > wordB[i])
                {
                    Console.WriteLine("Leksicaly first word is: {0} ", wordB);
                    break;
                }
                if (wordA[i] == wordB[i]&& i== wordA.Length-1)
                {
                    Console.WriteLine("Leksicaly first word is: {0} ", wordA);
                    break;
                }
            }
            
            
        }
    }
}
