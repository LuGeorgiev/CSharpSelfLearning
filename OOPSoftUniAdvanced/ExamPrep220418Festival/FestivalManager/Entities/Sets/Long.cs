using System;
using System.Collections.Generic;
using System.Text;

namespace FestivalManager.Entities.Sets
{
    public class Long : Set
    {
        private static readonly TimeSpan MaxDuration = new TimeSpan(0,60,0);

        public Long(string name) 
            : base(name, MaxDuration)
        {
            
        }
    }
}
