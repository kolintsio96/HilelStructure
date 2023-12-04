namespace Interface
{
    public interface IList : ICollection
    {
        int Capacity { get; }
        
        object this[int index] { get; set; }
        
        void Add(object data);
        
        void Insert(int index, object data);
        
        void Remove(object data);
        
        void RemoveAt(int index);
        
        int IndexOf(object data);
        
        void Reverse();
    }
}
