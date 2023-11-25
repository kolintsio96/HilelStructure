namespace Library
{
    public class Stack
    {
        LinkedList linkedList = new LinkedList();
        public int Count { get { return linkedList.Count; } }
        public void Push(object data)
        {            
            linkedList.AddFirst(data);
        }
        
        public object Pop()
        {
            if (linkedList.Count == 0)
            {
                throw new InvalidOperationException("Empty stack");
            }

            LinkedNode? temp = linkedList.First;
            linkedList.First = linkedList.First!.Next;
            linkedList.Count--;
            return temp!.Data;
        }
        
        public object Peek()
        {
            if (linkedList.Count == 0)
            {
                throw new InvalidOperationException("Empty stack");
            }

            return linkedList.First!.Data;
        }

        public bool Contains(object data)
        {
            return linkedList.Contains(data);
        }

        public void Clear()
        {
            linkedList.Clear();
        }

        public object[] ToArray()
        {
            return linkedList.ToArray();
        }
    }
}
