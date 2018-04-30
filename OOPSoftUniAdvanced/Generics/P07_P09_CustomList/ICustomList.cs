using System;
using System.Collections.Generic;
using System.Text;

namespace P07_P09_CustomList
{
    interface ICustomList<T>
    {
        IReadOnlyCollection<T> Items { get; }

        void Add(T element);
        T Remove(int index);
        bool Contains(T element);
        void Swap(int index1, int index2);
        int CountGreaterThan(T element);
        T Max();
        T Min();
        void Print();
    }
}
