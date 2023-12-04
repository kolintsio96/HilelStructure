namespace Interface
{
    public interface IStack : ICollection
    {
        void Push(object data);

        object Pop();

        object Peek();
    }
}
