using P08_MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace P08_MilitaryElite.Soldiers
{
    public enum Corps { Airforces, Marines,Invalid};

    public class SpecialisedSoldier : Private, ISpecialisedSoldier

    {
        private Corps soldierCorps;

        public Corps SoldierCorps
        {
            get
            {
                return this.soldierCorps;
            }
            private set
            {
                this.soldierCorps = value;
            }
        }

        public SpecialisedSoldier(int id, string firstName, string lastName, double salary, string corpOfSoldier)
            : base(id, firstName, lastName, salary)
        {
            ParsedCorps(corpOfSoldier);

        }

        private void ParsedCorps(string corpOfSoldier)
        {
            bool validCorp = Enum.TryParse(typeof(Corps), corpOfSoldier, out object outCorps);
            if (validCorp)
            {
                this.SoldierCorps = (Corps)outCorps;
            }
            else
            {
                throw new ArgumentException("Invalic Corps!");
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine($"Corps: {this.SoldierCorps.ToString()}");
            return sb.ToString().TrimEnd();
        }
    }
}
