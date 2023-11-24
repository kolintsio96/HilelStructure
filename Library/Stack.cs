namespace Library
{
    public struct Stack
    {
        private LinkedNode? First { get; set; }
        public int Count { get; private set; }

        public void Push(object data)
        {            
            LinkedNode node = new LinkedNode(data);
            node.Next = First;
            First = node;
            Count++;
        }
        
        public object Pop()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Empty stack");
            }

            LinkedNode? temp = First;
            First = First!.Next;
            Count--;
            return temp!.Data;
        }
        
        public object Peek()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Empty stack");
            }

            return First!.Data;
        }

        public bool Contains(object data)
        {
            LinkedNode? current = First;
            while (current != null)
            {
                if (current.Data.Equals(data)) return true;
                current = current.Next;
            }
            return false;
        }

        public void Clear()
        {
            Count = 0;
            First = null;
        }

        public object[] ToArray()
        {
            object[] result = new object[Count];
            int index = 0;
            LinkedNode? current = First;
            while (current != null)
            {
                result[index] = current.Data;
                current = current.Next;
                index++;
            }
            return result;
        }
    }
}
