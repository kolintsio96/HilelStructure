using Interface;
namespace Library
{
    public class LinkedNode : ILinkedNode
    {
        public LinkedNode(object data)
        {
            Data = data;
        }
        public object Data { get; }
        public ILinkedNode? Next { get; set; }

        public override string ToString()
        {
            return Data == null ? string.Empty : Data.ToString();
        }
    }
    public class LinkedList : ILinkedList
    {
        public ILinkedNode? First { get; protected set; }
        public ILinkedNode? Last { get; protected set; }
        public int Count { get; protected set; }

        public virtual void Add(object data)
        {
            ILinkedNode node = new LinkedNode(data);

            if (First == null)
            {
                First = node;
            } else
            {
                Last!.Next = node;
            }
               
            Last = node;

            Count++;
        }

        public virtual void AddFirst(object data)
        {
            LinkedNode node = new LinkedNode(data);
            node.Next = First;
            First = node;
            if (Count == 0)
            {
                Last = First;
            }
                
            Count++;
        }

        public object RemoveFirst()
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

        public void Insert(int index, object data)
        {
            if (index < 0 || index > Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            ILinkedNode newNode = new LinkedNode(data);

            if (index == 0)
            {
                AddFirst(data);
                return;
            }

            ILinkedNode current = First;

            for (int i = 0; i < index - 1 && current != null; i++)
            {
                current = current.Next;
            }

            if (current == null)
            {
                throw new ArgumentOutOfRangeException();
            }

            newNode.Next = current.Next;
            current.Next = newNode;
            Count++;
        }
        
        public bool Contains(object data)
        {
            ILinkedNode? current = First;
            while (current != null && current.Data != null)
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
            ILinkedNode? current = First;
            while (current != null && current.Data != null)
            {
                result[index] = current.Data;
                current = current.Next;
                index++;
            }
            return result;
        }
    }
}
