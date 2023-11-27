namespace Library
{
    public class DoubleLinkedNode : LinkedNode    {
        public DoubleLinkedNode(object data) : base(data) { }
        public DoubleLinkedNode? Previous { get; set; }
    }
    public class DoubleLinkedList : LinkedList
    {        
        public override void Add(object data)
        {
            DoubleLinkedNode node = new DoubleLinkedNode(data);
           
            if (First == null)
                First = node;
            else
            {
                Last!.Next = node;
                node.Previous = (DoubleLinkedNode)Last;
            }
            Last = node;
            Count++;
        }
        
        public override void AddFirst(object data)
        {
            DoubleLinkedNode node = new DoubleLinkedNode(data);
            DoubleLinkedNode? temp = (DoubleLinkedNode)First;
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
            DoubleLinkedNode? current = (DoubleLinkedNode)First;

            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    break;
                }
                current = (DoubleLinkedNode)current.Next;
            }
            if (current != null)
            {
                if (current.Next != null)
                {
                    DoubleLinkedNode next = (DoubleLinkedNode)current.Next;
                    next.Previous = current.Previous;
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
                    DoubleLinkedNode last = (DoubleLinkedNode)Last;
                    Last = last!.Previous;
                    Last!.Next = null;
                } else
                {
                    DoubleLinkedNode first = (DoubleLinkedNode)First;
                    First = first.Next;
                    first!.Previous = null;
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
    }
}
