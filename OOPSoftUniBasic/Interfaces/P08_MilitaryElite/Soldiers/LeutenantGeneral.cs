using P08_MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P08_MilitaryElite.Soldiers
{
    class LeutenantGeneral : Private,ILeutenantGeneral
    {
        private ICollection<ISoldier> privates;
        public IReadOnlyCollection<ISoldier> Privates
        {
            get { return (IReadOnlyCollection<ISoldier>)this.privates; }
            
        }

        public LeutenantGeneral(int id, string firstName, string lastName, double salary) : base(id, firstName, lastName, salary)
        {
            this.privates = new List<ISoldier>();
        }

        public void AddPrivate(ISoldier soldier)
        {
            this.privates.Add(soldier);
        }
        public void RemovePrivate(ISoldier soldier)
        {
            var soldierFound = this.Privates
                .FirstOrDefault(x => x == soldier);
            if (soldierFound==null)
            {
                throw new ArgumentException("No such Private found!");
            }
            else
            {
                this.privates.Remove(soldier);
            }
        }
        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine(base.ToString())
                .AppendLine("Privates:");

            foreach (var soldier in this.Privates)
            {
                sb.AppendLine($"  {soldier.ToString()}");
            }
            
            return sb.ToString().TrimEnd();
        }
    }
}
