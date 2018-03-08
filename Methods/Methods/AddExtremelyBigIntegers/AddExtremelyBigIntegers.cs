using System;


namespace AddExtremelyBigIntegers
{
    class AddExtremelyBigIntegers
    {

        //static byte[] GetBytes(string str)                                        //TO CHECK HOW IT WORKS
        //{
        //    byte[] bytes = new byte[str.Length * sizeof(char)];
        //    System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
        //    return bytes;
        //}

        //static string GetString(byte[] bytes)
        //{
        //    char[] chars = new char[bytes.Length / sizeof(char)];
        //    System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
        //    return new string(chars);
        //}

        static byte[] ReverseddNumberFromString(string number)
        {
            byte[] arr = new byte[number.Length];
            int n = number.Length-1;

            for (int i = 0; i <= n; i++)
            {
                if (number.EndsWith("0"))
                  arr[i] = 0;                
                else if(number.EndsWith("1"))
                    arr[i] = 1;
                else if (number.EndsWith("2"))
                    arr[i] = 2;
                else if (number.EndsWith("3"))
                    arr[i] = 3;
                else if (number.EndsWith("4"))
                    arr[i] = 4;
                else if (number.EndsWith("5"))
                    arr[i] = 5;
                else if (number.EndsWith("6"))
                    arr[i] = 6;
                else if (number.EndsWith("7"))
                    arr[i] = 7;
                else if (number.EndsWith("8"))
                    arr[i] = 8;
                else if (number.EndsWith("9"))
                    arr[i] = 9;
                else
                {
                    Console.WriteLine("incorrect symbol");
                    break;
                }
                number = number.Remove(number.Length - 1);
            }

            return arr;
        }

        static byte[] SumTwoArrays(int k, byte[] shorter, byte[] longer)
        {
            byte[] sum = new byte[longer.Length+1];

            for (int i = 0; i < k; i++)
            {
                sum[i] += Convert.ToByte((shorter[i] + longer[i])%10);

                if ((shorter[i] + longer[i])>=10)                
                    sum[i + 1] += 1;                
            }

            for (int i = k; i < longer.Length; i++)
            {
                if (sum[i] + longer[i] >= 10)
                    sum[i + 1] += 1;

                sum[i] = Convert.ToByte((sum[i] +longer[i])%10);
            }

            return sum;
        }
        
        static void Main()
        {
            string num1 = Console.ReadLine();
            byte[] number1 = new byte[num1.Length];
            string num2 = Console.ReadLine();
            byte[] number2 = new byte[num2.Length];
                        
            number1 = ReverseddNumberFromString(num1);              // convert string into revised array of byte type
            number2 = ReverseddNumberFromString(num2);

            int shorterEnd=number1.Length;                          // sums both arrays

            if (number2.Length > number1.Length)
                shorterEnd = number2.Length;

            byte[] sum = new byte[shorterEnd+1];

            if (number1.Length>number2.Length)
            {
                shorterEnd = number2.Length;                
                sum=SumTwoArrays(shorterEnd, number2, number1);
            }
            else
            {
                shorterEnd = number1.Length;
                sum=SumTwoArrays(shorterEnd, number1, number2);
            }

            if (sum[sum.Length-1]!=0)            
                Console.Write(sum[sum.Length - 1]);
            
            for (int i = sum.Length-2; i >=0; i--)            
                Console.Write(sum[i]);
            
            Console.WriteLine();            
        }
    }
}
