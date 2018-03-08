using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPExamples
{
    class Desktop : Computer, ISleep
    {
        private ISleep sleepController;
        public bool isSleeping
        {
            get
            {
                return sleepController.isSleeping;
            }
        }
        public enum CaseType
        {
            Tower,
            MiniTower
        }

        public CaseType caseType { get; private set; }

        public override string name
        { get
            {
                return base.name + " " + caseType;
            }
        }

        public Desktop(string name, CaseType caseType) : base(name)
        {
            this.caseType = caseType;
            sleepController = new SlepController();
            
        }

        public void ToggleSleep()
        {
            if (!isOn)
            {
                return;
            }

            sleepController.ToggleSleep();
        }

        public override void TogglePower()
        {
            if (isSleeping)
            {
                return;
            }
            base.TogglePower();
        }
    }
}
