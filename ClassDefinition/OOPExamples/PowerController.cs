using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPExamples
{
    class PowerController :IPowerOn
    {
        public bool isOn { get; private set; }

        protected void TurnOn()
        {
            this.isOn = true;
        }

        protected void TurnOff()
        {
            this.isOn = false;
        }

        public virtual void TogglePower()
        {
            if (isOn)
            {
                TurnOff();
            }
            else
            {
                TurnOn();
            }
        }
    }
}
