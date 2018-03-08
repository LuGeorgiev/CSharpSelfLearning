using System;


namespace EnterpriseInformation
{
    class EnterpriseInformation
    {
        static void Main()
        {
            Console.WriteLine("Please eneter enterprise name:");
            string entName = Console.ReadLine();
            Console.WriteLine("Please eneter enterprise address:");
            string entAddress = Console.ReadLine();
            Console.WriteLine("Please eneter enterprise telephone number:");
            uint entTel = uint.Parse(Console.ReadLine());
            Console.WriteLine("Please eneter enterprise fax number:");
            uint entFax = uint.Parse(Console.ReadLine());
            Console.WriteLine("Please eneter enterprise web site address:");
            string entWebSite = Console.ReadLine();
            Console.WriteLine("Please eneter enterprise manager first name:");
            string mngFirstName = Console.ReadLine();
            Console.WriteLine("Please eneter enterprise manager last name:");
            string mngLastName = Console.ReadLine();
            Console.WriteLine("Please eneter enterprise manager telephone number:");
            uint mngTel = uint.Parse(Console.ReadLine());

            Console.WriteLine("Enterprise  {0}\n Telephone {1:(0###) ### ###}\nFax:{2:(0###) ### ###} ", entName, entTel, entFax);
            Console.WriteLine("Enterprise address: {0}\nEnterprise Web Address:{1}", entAddress, entWebSite);
            Console.WriteLine("Enterprise Manager is:"+mngFirstName+" "+mngLastName);
            Console.WriteLine("Manager telephone number:{0:(0###) ### ###}", mngTel);
        } 
    }
}
