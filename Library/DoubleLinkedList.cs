namespace Library
{
    public class DoubleLinkedNode
    {
        public DoubleLinkedNode(object data)
        {
            Data = data;
        }
        public object Data { get; set; }
        public DoubleLinkedNode? Next { get; set; }

        public DoubleLinkedNode? Previous { get; set; }

        public override string ToString()
        {
            if (!Data.Equals(null))
            {
                return Data.ToString();
            }
            return "";
        }
    }
    public struct DoubleLinkedList
    {
        public DoubleLinkedNode? First { get; private set; }
        public DoubleLinkedNode? Last { get; private set; }
        public int Count { get; private set; }

        public void Add(object data)
        {
            DoubleLinkedNode node = new DoubleLinkedNode(data);

            if (First == null)
                First = node;
            else
            {
                Last!.Next = node;
                node.Previous = Last;
            }
            Last = node;
            Count++;
        }
        
        public void AddFirst(object data)
        {
            DoubleLinkedNode node = new DoubleLinkedNode(data);
            DoubleLinkedNode? temp = First;
            node.Next = temp;
            First = node;
            if (Count == 0)
            {
                Last = First;
            } else {
                temp!.Previous = node;
            }
                
            Count++;
        }

        public bool Remove(object data)
        {
            DoubleLinkedNode? current = First;

            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    break;
                }
                current = current.Next;
            }
            if (current != null)
            {
                if (current.Next != null)
                {
                    current.Next.Previous = current.Previous;
                }
                else
                {
                    Last = current.Previous;
                }

                if (current.Previous != null)
                {
                    current.Previous.Next = current.Next;
                }
                else
                {
                    First = current.Next;
                }
                Count--;
                return true;
            }
            return false;
        }

        private void RemoveElement(bool removeLast = false)
        {
            if (First == null)
            {
                throw new InvalidOperationException("The list is empty.");
            }

            if (First == Last)
            {
                First = null;
                Last = null;
            }
            else
            {
                if (removeLast)
                {
                    Last = Last!.Previous;
                    Last!.Next = null;
                } else
                {
                    First = First.Next;
                    First!.Previous = null;
                } 
            }
        }

        public void RemoveFirst()
        {
            RemoveElement();
        }

        public void RemoveLast()
        {
            RemoveElement(true);
        }

        public bool Contains(object data)
        {
            DoubleLinkedNode? current = First;
            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        public object[] ToArray()
        {
            object[] result = new object[Count];
            int index = 0;
            DoubleLinkedNode? current = First;
            while (current != null)
            {
                result[index] = current.Data;
                current = current.Next;
                index++;
            }
            return result;
        }

        public void Clear()
        {
            First = null;
            Last = null;
            Count = 0;
        }
    }
}
