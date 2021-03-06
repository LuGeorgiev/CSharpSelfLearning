﻿using P08_MilitaryElite.Interfaces.IUtilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace P08_MilitaryElite.Soldiers
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        private ICollection<IRepair> repairs;

        public IReadOnlyCollection<IRepair> Repairs
        {
            get
            {
                return (IReadOnlyCollection<IRepair>) repairs;
            }
        }        

        public Engineer(int id, string firstName, string lastName, double salary, string soldierCorps) 
            : base(id, firstName, lastName, salary, soldierCorps)
        {
            this.repairs = new List<IRepair>();
        }

        public void AddRepairItem(IRepair item)
        {
            this.repairs.Add(item);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("Repairs:");
            foreach (var item in this.Repairs)
            {
                sb.AppendLine($"  {item.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
