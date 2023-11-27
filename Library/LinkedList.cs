
using System.Collections.Generic;

namespace Library
{
    public class LinkedNode
    {
        public LinkedNode(object data)
        {
            Data = data;
        }
        public object Data { get; }
        public LinkedNode? Next { get; set; }

        public override string ToString()
        {
            return Data == null ? string.Empty : Data.ToString();
        }
    }
    public class LinkedList
    {
        public LinkedNode? First { get; protected set; }
        public LinkedNode? Last { get; protected set; }
        public int Count { get; protected set; }

        public virtual void Add(object data)
        {
            LinkedNode node = new LinkedNode(data);

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

            LinkedNode newNode = new LinkedNode(data);

            if (index == 0)
            {
                AddFirst(data);
                return;
            }

            LinkedNode current = First;

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
            LinkedNode? current = First;
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
            LinkedNode? current = First;
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
