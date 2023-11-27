namespace Interface
{
    public interface IDoubleLinkedNode : ILinkedNode
    {
        IDoubleLinkedNode Previous { get; set; }
    }

    public interface IDoubleLinkedList : ILinkedList
    {
        bool Remove(object data);

        void RemoveLast();
    }
}
