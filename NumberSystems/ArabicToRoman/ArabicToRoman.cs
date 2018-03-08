using System;


namespace ArabicToRoman
{
    class ArabicToRoman
    {
        static void Main()
        {
            int num = int.Parse(Console.ReadLine());     // additionally 4 and 9 can be included with two if for each check
            string arabicNum = null;
            char letter='\u0000';

            while (num!=0)
            {
                int substract = 0;

                if (num>=1000)
                {
                    substract = 1000;
                    letter = 'M';
                }
                else if (num < 1000&& num>=500)
                {
                    substract = 500;
                    letter = 'D';
                }
                else if (num < 500 && num >= 100)
                {
                    substract = 100;
                    letter = 'C';
                }
                else if (num < 100 && num >= 50)
                {
                    substract = 50;
                    letter = 'L';
                }
                else if (num < 50 && num >= 10)
                {
                    substract = 10;
                    letter = 'X';
                }
                else if (num < 10 && num >= 5)
                {
                    substract = 5;
                    letter = 'V';
                }
                else if (num < 5 && num >= 1)
                {
                    substract = 1;
                    letter = 'I';
                }

                num = num - substract;
                arabicNum = arabicNum + letter;

            }
            Console.WriteLine(arabicNum);
        }
    }
}
