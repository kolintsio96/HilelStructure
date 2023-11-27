namespace Library
{
    public class Queue
    {
        private LinkedList linkedList = new LinkedList();
        public int Count {  get { return linkedList.Count; } }
        public void Enqueue(object data)
        {
            linkedList.Add(data);
        }

        public object Dequeue()
        {
            return linkedList.RemoveFirst();
        }

        public object Peek()
        {
            if (linkedList.Count == 0)
            {
                throw new InvalidOperationException();
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
