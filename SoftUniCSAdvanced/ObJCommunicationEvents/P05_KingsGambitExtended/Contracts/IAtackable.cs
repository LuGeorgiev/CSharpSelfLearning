﻿using System;
using System.Collections.Generic;
using System.Text;

namespace P05_KingsGambit.Contracts
{
    public delegate void GetAttackedEventHandler();
    public interface IAtackable
    {
        event GetAttackedEventHandler GetAttackedEvent;
        void GetAttacked();
    }
}
