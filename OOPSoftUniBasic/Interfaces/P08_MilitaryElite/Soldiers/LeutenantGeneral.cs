using P08_MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P08_MilitaryElite.Soldiers
{
    class LeutenantGeneral : Private,ILeutenantGeneral
    {
        private List<IPrivate> privates;
        public List<IPrivate> Privates
        {
            get { return privates; }
            private set { privates = value; }
        }

        public LeutenantGeneral(string id, string firstName, string lastName, double salary) : base(id, firstName, lastName, salary)
        {
            this.Privates = new List<IPrivate>();
        }

        public void AddPrivate(IPrivate soldier)
        {
            this.Privates.Add(soldier);
        }
        public void RemovePrivate(IPrivate soldier)
        {
            var soldierFound = this.Privates
                .FirstOrDefault(x => x == soldier);
            if (soldierFound==null)
            {
                throw new ArgumentException("No such Private found!");
            }
            else
            {
                this.Privates.Remove(soldier);
            }
        }
        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine(base.ToString())
                .AppendLine("Privates:");

            foreach (var soldier in this.Privates)
            {
                sb.AppendLine(soldier.ToString());
            }
            
            return sb.ToString().TrimEnd();
        }
    }
}
