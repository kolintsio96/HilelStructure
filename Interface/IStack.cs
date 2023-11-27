namespace Interface
{
    public interface IStack
    {
        void Push(object data);

        object Pop();

        object Peek();
    }
}
