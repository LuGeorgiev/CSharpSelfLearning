using System;
using System.Collections.Generic;
using System.Text;

namespace P02_KingsGambit.Models
{
    public class Footman : Subordinate
    {
        public Footman(string name) 
            : base(name, "panicking")
        {
        }       
    }
}
