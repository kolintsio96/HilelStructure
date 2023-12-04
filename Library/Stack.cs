using Interface;
namespace Library
{
    public class Stack<T> : IStack<T>
    {
        private ILinkedList<T> linkedList = new LinkedList<T>();
        public int Count { get { return linkedList.Count; } }
        public void Push(T data)
        {            
            linkedList.AddFirst(data);
        }
        
        public T Pop()
        {
            return linkedList.RemoveFirst();
        }
        
        public T Peek()
        {
            if (linkedList.Count == 0)
            {
                throw new InvalidOperationException("Empty stack");
            }

            return linkedList.First!.Data;
        }

        public bool Contains(T data)
        {
            return linkedList.Contains(data);
        }

        public void Clear()
        {
            linkedList.Clear();
        }

        public T[] ToArray()
        {
            return linkedList.ToArray();
        }
    }
}
