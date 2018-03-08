using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Falidae
{
    public abstract class Falidae
    {
        private bool male;

        public Falidae() :this(true)
        {
        }

        public Falidae(bool male)
        {
            this.male = male;
        }

        public bool Male
        {
            get
            {
                return male;
            }
            set
            {
                this.male = value;
            }
        }
        protected void Hide()
        {

        }

        protected void Run()
        {

        }
        public virtual void CatchPray(object pray) { }
    }
}
