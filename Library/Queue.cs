using Interface;
namespace Library
{
    public class Queue<T> : IQueue<T>
    {
        private ILinkedList<T> linkedList = new LinkedList<T>();
        public int Count {  get { return linkedList.Count; } }
        public void Enqueue(T data)
        {
            linkedList.Add(data);
        }

        public T Dequeue()
        {
            return linkedList.RemoveFirst();
        }

        public T Peek()
        {
            if (linkedList.Count == 0)
            {
                throw new InvalidOperationException();
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
