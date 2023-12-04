namespace Interface
{
    public interface ICollection
    {
        int Count { get; }

        void Clear();

        object[] ToArray();

        bool Contains(object data);

    }
}
