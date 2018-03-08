using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashDictionary
{
    public class HashDictionary<K,V>: 
        IEnumerable<KeyValuePair<K, V>>
    {
        private const int DEFAULT_CAPACITY = 2;
        private const float DEFAULT_LOAD_FACTOR = 0.75f;
        private List<KeyValuePair<K, V>>[] table;
        private float loadFactor;
        private int size;
        private int initialCapacity;
        private int treshold;

        public HashDictionary()
            :this (DEFAULT_CAPACITY,DEFAULT_LOAD_FACTOR)
        {
        }

        private HashDictionary(int capacity, float loadFactor)
        {
            this.initialCapacity = capacity;
            this.loadFactor = loadFactor;
            this.table = new List<KeyValuePair<K, V>>[capacity];
            unchecked
            {
                this.treshold = (int)(capacity * this.loadFactor);
            }
        }

        public void Clear()
        {
            if (this.table!=null)
            {
                this.table = new List<KeyValuePair<K, V>>[initialCapacity];
            }
            this.size = 0;
        }

        private List<KeyValuePair<K, V>> FindChain(K key, bool creatIfMissing)
        {
            int index = key.GetHashCode();
            index = index % this.table.Length;
            if (this.table[index] == null && creatIfMissing)
            {
                this.table[index] = new List<KeyValuePair<K, V>>();
            }
            return this.table[index] as List<KeyValuePair<K, V>>;
        }

        public V Get(K key)
        {
            List<KeyValuePair<K, V>> chain = this.FindChain(key, false);
            if (chain!=null)
            {
                foreach (var entry in chain)
                {
                    if (entry.Key.Equals(key))
                    {
                        return entry.Value;
                    }
                }
            }
            return default(V);
        }

        public V this[K key]
        {
            get { return this.Get(key); }
            set { this.Set(key, value); }
        }

        public int Count
        {
            get
            {
                return this.size;
            }
        }

        public V Set(K key, V value)
        {
            List<KeyValuePair<K, V>> chain = this.FindChain(key, true);

            for (int i = 0; i < chain.Count; i++)
            {
                KeyValuePair<K, V> entry = chain[i];
                if (entry.Key.Equals(key))
                {
                    KeyValuePair<K, V> newEntry = new KeyValuePair<K, V>(key, value);
                    chain[i] = newEntry;
                    return entry.Value;
                }
            }
            chain.Add(new KeyValuePair<K, V>(key, value));
            if (size++>=treshold)
            {
                this.Expand();
            }
            return default(V);
        }

        private void Expand()
        {
            int newCapacity = 2 * this.table.Length;
            List<KeyValuePair<K, V>> oldTable = this.table;
            this.table = new List<KeyValuePair<K, V>>[newCapacity];
            this.treshold = (int)(newCapacity * this.loadFactor);
            foreach (var oldChain in oldTable)
            {
                if (oldChain!=null)
                {
                    for (int i = 0; i < chain.Count; i++)
                    {
                        KeyValuePair<K, V> entry = chain[i];
                    }
                }
            }
        }

        IEnumerator<KeyValuePair<K, V>>
            IEnumerable<KeyValuePair<K, V>>.GetEnumerator()
        {
            foreach (List<KeyValuePair<K,V>> chain in this.table)
            {
                if (chain!=null)
                {
                    foreach (KeyValuePair<K,V> entry in chain)
                    {
                        yield return entry;
                    }
                }
            }
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<KeyValuePair<K, V>>)this).GetEnumerator();
        }
    }
}
