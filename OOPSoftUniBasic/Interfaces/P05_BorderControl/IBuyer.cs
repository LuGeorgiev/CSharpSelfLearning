using System;
using System.Collections.Generic;
using System.Text;

namespace P05_BorderControl
{
    public interface IBuyer
    {
        int Food { get; }
        void BuyFood();
    }
}
