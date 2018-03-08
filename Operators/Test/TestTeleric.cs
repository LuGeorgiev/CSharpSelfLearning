using System;


namespace Test
{
    class TestTeleric
    {
        static void Main()
        {
            //int magic = int.Parse(Console.ReadLine());                                      //Mythical numbers 10 NOV 2016
            //int a = magic / 100;
            //int b = (magic % 100) / 10;
            //int c = magic % 10;
            //double result;
            //if (c==0)
            //{
            //    result = a * b;
            //}
            //else if(c>0&&c<=5)
            //{
            //    result = (double)a * b / c;
            //}
            //else
            //{
            //    result = (a + b) * c;
            //}

            //Console.WriteLine("{0:F2}",result);

            //string jumpSequence = Console.ReadLine();                            JUMP JUMP JUMP
            //int index = 0;                      

            //do
            //{
            //    if (index < 0 || index > jumpSequence.Length-1)
            //    {
            //        Console.WriteLine("Fell off the dancefloor at {0}!", index);
            //        break;
            //    }
            //    else if (jumpSequence[index] == '^')
            //    {
            //        Console.WriteLine("Jump, Jump, DJ Tomekk kommt at {0}!", index);
            //        break;
            //    }
            //    else if (jumpSequence[index] == '0')
            //    {
            //        Console.WriteLine("Too drunk to go on after {0}!", index);
            //        break;
            //    }
            //    else if ((int)jumpSequence[index] % 2 == 1)
            //    {
            //        index = index - ((int)jumpSequence[index]-48);
            //    }
            //    else if (((int)jumpSequence[index] % 2) == 0)
            //    {
            //        index = index + ((int)jumpSequence[index] - 48);
            //    }


            //} while (true);



            //int start=0;                              CODING GAME
            //int jump = 0;
            //string message;
            //string condition;
            //string code=null;
            //do
            //{
            //    condition = Console.ReadLine();
            //    if (condition=="end")
            //    {
            //        break;
            //    }
            //    start = int.Parse(condition);
            //    jump= int.Parse(Console.ReadLine());
            //    message = Console.ReadLine();

            //    if (start<0)
            //    {
            //        start = message.Length + start;
            //    }

            //    for (int i = start; i < message.Length && i>=0; i+= jump)
            //    {
            //        code = code + message[i];
            //    }

            //} while (true);

            //Console.WriteLine(code);

                                                                            //MIXING NUMBERS    
            int n = int.Parse(Console.ReadLine());
            int[] numbers = new int[n];
            int[] mix = new int[n-1];
            int[] subtract = new int[n-1];

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }

            for (int i = 0; i < numbers.Length-1; i++)
            {
                mix[i] = (numbers[i] % 10) * (numbers[i + 1] / 10);
                subtract[i] = Math.Abs(numbers[i] - numbers[i + 1]);
            }

            Console.WriteLine(string.Join(" ", mix));
            Console.WriteLine(string.Join(" ", subtract));


        }
    }
}
