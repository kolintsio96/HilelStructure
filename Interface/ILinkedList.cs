namespace Interface
{
    public interface ILinkedNode
    {
        object Data { get; }

        ILinkedNode Next { get; set; }
    }
    
    public interface ILinkedList : ICollection
    {
        ILinkedNode First { get; }

        ILinkedNode Last { get; }

        void Add(object data);
        
        void AddFirst(object data);
        
        object RemoveFirst();

        void Insert(int index, object data);
    }
}
