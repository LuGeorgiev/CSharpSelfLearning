using System;


namespace SumOfNNumbers
{
    class SumOfN
    {
        static void Main()
            
        {
            int lineLength;
            int[] line = new int[1]; 
            int sum=0;

            Console.WriteLine("Please insert line length and have in mind that all the coeficients have to be enterd afterwards");
            while (!int.TryParse(Console.ReadLine(), out lineLength))
            {
                Console.WriteLine("Focus, mate the length have to be positive integer");
            }
            Console.WriteLine("Now eneter all the coeficients");

            
            Array.Resize<int>(ref line, lineLength);

            for (int i = 0; i < lineLength; i++)
            {
                while (!int.TryParse(Console.ReadLine(), out line[i]))
                {
                    Console.WriteLine("Do not sleep mother fOcker and enter integer");
                }
                sum += line[i];
            }
            Console.WriteLine("The sum fo the line is: {0}", sum);
        }
    }
}
