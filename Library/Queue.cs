namespace Library
{
    public struct Queue
    {
        private LinkedNode? First { get; set; }
        private LinkedNode? Last { get; set; }
        public int Count { get; private set; }

        public void Enqueue(object data)
        {
            LinkedNode node = new LinkedNode(data);
            LinkedNode tempNode = Last;
            Last = node;
            if (Count == 0)
            {
                First = Last;
            } else
            {
                tempNode!.Next = Last;
            }
                
            Count++;
        }

        public object Dequeue()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }

            object result = First!.Data;
            First = First.Next;
            Count--;
            return result;
        }

        public object Peek()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
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
            Last = null;
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
