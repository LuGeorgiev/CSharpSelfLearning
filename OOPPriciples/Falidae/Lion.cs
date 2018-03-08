using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Falidae
{
    public class Lion : Falidae
    {
        private int weight;

        public Lion(bool male, int weight) : base(male)
        {
            this.weight = weight;
            base.Male = male;
        }

        public int Weight
        {
            get
            {
                return weight;
            }
            set
            {
                this.weight = value;
            }
        }
        protected void Aush()
        {
        }
        public override void CatchPray(object pray)
        {
            Console.WriteLine("Lion. CatchPary");
        }
    }
}
