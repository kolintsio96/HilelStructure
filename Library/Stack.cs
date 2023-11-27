namespace Library
{
    public class Stack
    {
        private LinkedList linkedList = new LinkedList();
        public int Count { get { return linkedList.Count; } }
        public void Push(object data)
        {            
            linkedList.AddFirst(data);
        }
        
        public object Pop()
        {
            return linkedList.RemoveFirst();
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
