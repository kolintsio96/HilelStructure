namespace Interface
{
    public interface IQueue : ICollection
    {
        void Enqueue(object data);

        object Dequeue();

        object Peek();
    }
}
