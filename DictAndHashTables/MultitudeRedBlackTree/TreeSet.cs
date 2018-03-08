using System;
using System.Collections.Generic;


namespace MultitudeRedBlackTree
{   

    /// <summary>
    /// Class that represents ordered set, based on SortedDictionary
    /// </summary>
    /// <typeparam name="T">The type of the elements
    /// in the set</typeparam>
    public class TreeSet<T> : ICollection<T>
    {
        private SortedDictionary<T, bool> innerDictionary;

        public TreeSet(IEnumerable<T> element) : this()
        {
            foreach (T item in element)
            {
                this.Add(item);
            }
        }

        public TreeSet()
        {
            this.innerDictionary = new SortedDictionary<T, bool>();
        }

        /// <summary>
        /// Adds an element to the set.
        /// </summary>
        /// <param name="element">element to add</param>
        /// <returns>true if the element has not been
        /// already added, false otherwise</returns>
        public bool Add(T element)
        {
            if (!innerDictionary.ContainsKey(element))
            {
                this.innerDictionary[element] = true;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Performs intersection of this set with the specified set
        /// </summary>
        /// <param name="other">Set to intersect with</param>
        public void IntersectWith(TreeSet<T> other)
        {
            List<T> elementsToRemove =
                  new List<T>(Math.Min(this.Count, other.Count));

            foreach (T key in this.innerDictionary.Keys)
            {
                if (!other.Contains(key))
                {
                    elementsToRemove.Add(key);
                }
            }

            foreach (T elementToRemove in elementsToRemove)
            {
                this.Remove(elementToRemove);
            }
        }

        /// <summary>
        /// Performs an union operation with another set
        /// </summary>
        /// <param name="other">The set to perform union with</param>
        public void UnionWith(TreeSet<T> other)
        {
            foreach (T key in other)
            {
                this.innerDictionary[key] = true;
            }
        }

        #region ICollection<T> Members

        void ICollection<T>.Add(T item)
        {
            this.Add(item);
        }

        public void Clear()
        {
            this.innerDictionary.Clear();
        }

        public bool Contains(T item)
        {
            return this.innerDictionary.ContainsKey(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            this.innerDictionary.Keys.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return this.innerDictionary.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(T item)
        {
            return this.innerDictionary.Remove(item);
        }

        #endregion

        #region IEnumerable<T> Members

        public IEnumerator<T> GetEnumerator()
        {
            return this.innerDictionary.Keys.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator
              System.Collections.IEnumerable.GetEnumerator()
        {
            return innerDictionary.Keys.GetEnumerator();
        }

        #endregion
    }
}
