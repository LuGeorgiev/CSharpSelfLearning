using System;
using System.Linq;
using System.Collections.Generic;


namespace Utilities
{
    public class MathUtils
    {
        public int Sum(IEnumerable<int> numbers)
        {
            if (numbers==null)
            {
                throw new ArgumentException();
            }
            var sum = numbers.Sum(x => x);
            return sum;
        }
    }
}
