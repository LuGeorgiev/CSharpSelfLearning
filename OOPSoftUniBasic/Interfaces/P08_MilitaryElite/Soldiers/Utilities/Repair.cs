using P08_MilitaryElite.Interfaces.IUtilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace P08_MilitaryElite.Soldiers.Utilities
{
    public class Repair:IRepair
    {
        public string PartName { get; private set; }
        public int HoursWorked { get; private set; }

        public Repair(string partName, int hoursWorked)
        {
            this.PartName = partName;
            this.HoursWorked = hoursWorked;
        }
        public override string ToString()
        {
            return $"  Part Name: {this.PartName} Hours Worked: {this.HoursWorked}";
        }
    }
}
