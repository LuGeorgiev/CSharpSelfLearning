using System;
using System.Collections.Generic;


namespace HashDictionary
{
    public interface IDictionary<K, V>:
        IEnumerable<KeyValuePair<K, V>>
    {
        V Set(K key, V value);
        V Get(K Key);
        V this[K key] { get; set; }
        bool Remove(K key);
        int Count { get; }
        void Clear();
    }
}
