using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P04_Froggy
{
    public class Lake<T> : IEnumerable<T>
    {
        private List<T> stones;

        public Lake(params T[] stonesNames)
        {
            this.stones = new List<T>();
            this.stones.AddRange(stonesNames);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < stones.Count; i+=2)
            {
                yield return this.stones[i]; 
            }
            for (int i = stones.Count-1; i>=0; i--)
            {
                if (i%2==1)
                {
                    yield return this.stones[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
