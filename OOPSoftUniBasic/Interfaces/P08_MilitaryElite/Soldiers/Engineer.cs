using P08_MilitaryElite.Interfaces.IUtilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace P08_MilitaryElite.Soldiers
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        public List<IRepair> Repairs { get; private set; }        

        public Engineer(string id, string firstName, string lastName, double salary, string soldierCorps) 
            : base(id, firstName, lastName, salary, soldierCorps)
        {
            this.Repairs = new List<IRepair>();
        }

        public void AddRepairItem(IRepair item)
        {
            this.Repairs.Add(item);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("Missions:");
            foreach (var item in this.Repairs)
            {
                sb.AppendLine($"  {item.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
