using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPExamples
{
    interface ISleep
    {
        bool isSleeping { get; }
        void ToggleSleep();
    }
}
