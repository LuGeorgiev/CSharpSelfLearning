using System;
using System.Collections.Generic;


namespace MobilePhone
{
    public enum CalType { Incoming, Outgoing,Unanswered }

    class Phone  //Task 15-19 still not solved
    {
        static void Main()
        {
            var first = new Phone("iPhone X","Apple",2300);
            var second = new Phone("Note 8","Samsung",1800,"Ivan Petrov");
            var third = new Phone("iPhone 6","Apple",1300,"1800x1200p","64M");
            var forth = new Phone("N95","Nokia",800, "Petko Kucia", "1200x800", "12k", BatteryType.NiMh ,18, 6.8f);

            //third.PrintPhoneInfo();
            //PrintFromStaticField();
            //GSMTest.PrintInfo(forth);

            forth.AddCallInfo(2356, CalType.Incoming);
            forth.AddCallInfo(3456, CalType.Outgoing);
            forth.AddCallInfo(0, CalType.Unanswered);
        }

        private string model;
        private string vendor;
        private int price;
        private string displaySize;
        private string displayColors;
        private string owner;
        private BatteryType bateryType;
        private int hoursTalk;
        private float idleTime;
        private static string nokiaN95="ner";

        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }
        public string Vendor
        {
            get { return this.vendor; }
            set { this.vendor = value; }
        }
        public int Price
        {
            get { return this.price; }
            set { this.price= value; }
        }
        public string DispalySize
        {
            get { return this.displaySize; }
            set { this.displaySize= value; }
        }
        public string DisplayColors
        {
            get { return this.displayColors; }
            set { this.displayColors= value; }
        }
        public string Owner
        {
            get { return this.owner; }
            set { this.owner= value; }
        }
        public BatteryType Battery
        {
            get { return this.bateryType; }
            set { this.bateryType = value; }
        }
        public int HoursToTalk
        {
            get { return this.hoursTalk; }
            set { this.hoursTalk= value; }
        }
        public float IdleTime
        {
            get { return this.idleTime; }
            set { this.idleTime= value; }
        }


        internal List<DateTime> TimeOfCall { get; private set; } //not working properly
        internal List<int> CallDuration { get; private set; }
        internal List<CalType> TypeOfCall { get; private set; }




        public Phone(string model, string vendor, int price)
        {
            this.model = model;
            this.vendor = vendor;
            this.price = price;            
        }
        public Phone(string model, string vendor, int price, string owner)
        {
            this.model = model;
            this.vendor = vendor;
            this.price = price;
            this.owner = owner;
        }
        public Phone(string model, string vendor, int price, string disSize, string disCol)
        {
            this.model = model;
            this.vendor = vendor;
            this.price = price;
            this.displaySize = disSize;
            this.displayColors = disCol;
        }
        public Phone(string model, string vendor, int price, string owner, string disSize, string disCol, BatteryType bat, int hour, float idle)
        {
            this.model = model;
            this.vendor = vendor;
            this.price = price;
            this.owner = owner;
            this.displaySize = disSize;
            this.displayColors = disCol;
            this.bateryType = bat;
            this.hoursTalk = hour;
            this.idleTime = idle;
        }

        public enum BatteryType
        {
            LiIon, NiMh,NiCD,Other
        }

        public static void PrintFromStaticField()
        {
            Console.WriteLine(Phone.nokiaN95);
        }

        internal void PrintPhoneInfo()
        {
            Console.WriteLine("Model: {0}, by {1} , and costs: {2} BGN", this.model, this.vendor, this.price);
            if (this.owner!=null)
                Console.WriteLine($"It is owned by: {this.owner}");
            if (this.displaySize!=null)
                Console.WriteLine($"Display characteristics are: size {this.displaySize} and has {this.displayColors} colors.");
            if (this.bateryType!=0)
                Console.WriteLine($"Baterry material is {this.bateryType}, can handle {this.hoursTalk} hours talking and {this.idleTime} days in standby mode");
            Console.WriteLine();
        }

        public void AddCallInfo(int secondsDuartion, CalType type)                      // NOT working properly
        {            
            this.TimeOfCall.Add(DateTime.Now);
            this.CallDuration.Add(secondsDuartion);
            this.TypeOfCall.Add(type);
        }

    }
     
    class GSMTest
    {
        public static void PrintInfo(Phone phone)
        {
            phone.PrintPhoneInfo();
        }
    }
}
