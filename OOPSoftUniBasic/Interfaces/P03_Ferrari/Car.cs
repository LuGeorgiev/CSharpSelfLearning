using System;
using System.Collections.Generic;
using System.Text;

namespace P03_Ferrari
{
    public class Car:IAcceleratable,IBreakable
    {
        public string Model { get; set; } = "488-Spider";
        public string  Driver { get; set; }

        public Car(string name)
        {
            this.Driver = name;
        }
        public string Brakes()
        {
            return "Brakes!";
        }

        public string GasPedal()
        {
            return "Zadu6avam sA!";
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{this.Model}/{this.Brakes()}/{this.GasPedal()}/{this.Driver}");

            return sb.ToString().TrimEnd();
        }
    }
}
