using System;
using System.Collections.Generic;
using System.Text;

namespace P10_P11_Tuple
{
    public class CustTuple<T1,T2>
    {
        private T1 element1;
        private T2 element2;

        public CustTuple(T1 elem1, T2 elem2)
        {
            this.element1 = elem1;
            this.element2 = elem2;
        }

        public override string ToString()
        {
            return $"{this.element1} -> {this.element2}";
        }
    }
}
