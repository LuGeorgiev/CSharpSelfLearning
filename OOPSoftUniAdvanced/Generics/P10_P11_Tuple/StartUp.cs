using System;
using System.Collections.Generic;

namespace P10_P11_Tuple
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            // P11 Threeuple is trivial

            var nameAndAddress = Console.ReadLine().Split();
            var name = nameAndAddress[0] + " " + nameAndAddress[1];
            var address = nameAndAddress[2];
            var nameAddressTuple = new CustTuple<string, string>(name, address);
            Console.WriteLine(nameAddressTuple);

            var nameLittersBeer = Console.ReadLine().Split();
            var nickName = nameLittersBeer[0];
            var litters = int.Parse(nameLittersBeer[1]);
            var nickBeerTuple = new CustTuple<string, int>(nickName, litters);
            Console.WriteLine(nickBeerTuple);

            var intDoubl = Console.ReadLine().Split();
            var intInput =int.Parse( intDoubl[0]);
            var doubleInput = double.Parse(intDoubl[1]);
            var intDoubTuple = new CustTuple<int, double>(intInput, doubleInput);
            Console.WriteLine(intDoubTuple);           

        }
    }
}
