using System.Collections.Generic;

namespace P02_ListIterator
{
    public interface IListyItaerator<T>
    {
        bool HasNext();
        bool MoveTo();
        void Print();
        void PrintAll();

        IReadOnlyCollection<T> Elements { get; }
        int Index { get; }
    }
}