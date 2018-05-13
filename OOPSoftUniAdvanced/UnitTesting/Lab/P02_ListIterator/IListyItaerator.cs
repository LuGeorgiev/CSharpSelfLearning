using System.Collections.Generic;

namespace P02_ListIterator
{
    public interface IListyItaerator<T>
    {
        bool HasNext();
        bool MoveTo();
        string Print();
        string PrintAll();

        IReadOnlyCollection<T> Elements { get; }
        int Index { get; }
    }
}