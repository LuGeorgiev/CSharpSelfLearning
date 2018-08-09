namespace CustomLinkedList
{
    public interface IDynamicList<T>
    {
        T this[int index] { get; set; }

        int Count { get; }

        void Add(T item);
        bool Contains(T item);
        int IndexOf(T item);
        int Remove(T item);
        T RemoveAt(int index);
    }
}