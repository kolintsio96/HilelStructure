namespace Interface
{
    public interface IQueue
    {
        void Enqueue(object data);

        object Dequeue();

        object Peek();
    }
}
