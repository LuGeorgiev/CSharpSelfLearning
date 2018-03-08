using System;


namespace ArrayMethods
{
    class ArrayMethods
    {
        static int RepeatsInArray(int num, int[] arr)
        {
            int repeat = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                
                if (num==arr[i])
                {
                    repeat++;
                }
            }
            return repeat;
        }

        static bool BiggerThanNeightbours(int position, int[] arr) // not starting from 0
        {
            bool big = false;
            if (position-1==0)
            {
                if (arr[position - 1] > arr[position])
                    big = true;
            }
            else if (position==arr.Length)
            {
                if (arr[position - 1] > arr[position-2])
                    big = true;
            }
            else
            {
                if (arr[position - 1] > arr[position - 2]&& arr[position - 1] > arr[position])
                    big = true;
            }

            return big;
        }

        static void ReversedNumber(int number)
        {
            string reversed=null;
            int digit = 0;
            if (number == 0)
                reversed= "0";
            if (number<0)
            {
                number = -1 * number;
                reversed = "-";
            }
            while (number!=0)
            {
                digit= number % 10;
                number /= 10;
                reversed += digit;
            }
            Console.WriteLine(reversed);
        }

        static void Main()
        {
            int num = 123456;                                                       // Display digits from back to begining of an integer
            ReversedNumber(num);



            //int[] myArray = {1,2,18,19,20};                                       // Returns the first bigger than BOTH neightbours array ember OR -1
            //bool bigger=false;
            //for (int i = 1; i < myArray.Length-1; i++)
            //{
            //    bigger = BiggerThanNeightbours((i+1), myArray);
            //    if (bigger)
            //    {
            //        Console.WriteLine("The number on position {0} is the first bigger than its both neighbours", (i+1));
            //        break;
            //    }
            //}
            //if (!bigger)
            //   Console.WriteLine("-1");
            

            //int seededNumber = 13;                                            // calculates how many times a digit is repeated in an array
            //int repetition = RepeatsInArray(seededNumber, myArray);
            //if (repetition==0)            
            //    Console.WriteLine("there is no {0} in this array", seededNumber);            
            //else            
            //    Console.WriteLine("{0} was found {1} times in this array", seededNumber, repetition);


        }
    }
}
