using Interface;
namespace Library
{
    public struct List : IList
    {
        private object[] data;
        public int Capacity { get; private set; } = 4;
        private object[] emptyArray = Array.Empty<object>();

        public int Count { get; private set; } = 0;

        public List()
        {
            data = new object[Capacity];
        }
        
        public List(int capacity)
        {
            Capacity = capacity;
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException();
            } else if (capacity == 0)
            {
                data = emptyArray;
            } else
            {
                data = new object[capacity];
            }
        }

        public object this[int index]
        {
            get
            {
                if(index <= Count)
                {
                    return data[index];
                } else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }

            set
            {
                if (index <= Count)
                {
                    data[index] = value;
                } else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }
        
        public void Add(object value)
        {
            Count++;
            object[] array = data;

            if (Count > Capacity)
            {
                Capacity = Count * 2;
                data = new object[Capacity];

                for (int i = 0; i < Count; i++)
                {
                    if (i == Count - 1)
                    {
                        data[i] = value;
                    }
                    else
                    {
                        data[i] = array[i];
                    }

                }
            } else
            {
                data[Count - 1] = value;
            }

        }

        public void Insert(int index, object value)
        {
            if (index < 0 || index > Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            bool inserted = false;
            Count++;

            object[] array = data;

            if (Count > Capacity)
            {
                Capacity = Count;
                data = new object[Capacity];
            }

            for (int i = 0; i < Count; i++)
            {
                if (i == index)
                {
                    data[i] = value;
                    inserted = true;
                }
                else
                {
                    if (!inserted)
                    {
                        data[i] = array[i];
                    }
                    else
                    {
                        data[i] = array[i - 1];
                    }

                }

            }
        }
        
        public void Remove(object value)
        {
            int index = IndexOf(value);
            if (index != -1)
            {
                RemoveAt(index);
            }
        }
        
        public void RemoveAt(int index)
        {
            if (index < 0 || index > Count - 1)
            {
                throw new ArgumentOutOfRangeException();
            }

            bool skipped = false;

            Count--;

            object[] array = data;

            data = new object[Count];

            for (int i = 0; i < Count + 1; i++)
            {
                if (i == index)
                {
                    skipped = true;
                    continue;
                }
                else
                {
                    if (!skipped)
                    {
                        data[i] = array[i];
                    }
                    else
                    {
                        data[i - 1] = array[i];
                    }

                }

            }
        }

        public void Clear()
        {
            data = emptyArray;
            Count = 0;
            Capacity = 4;
        }

        public bool Contains(object value)
        {
            return IndexOf(value) != -1;
        }

        public int IndexOf(object value) {
            for (int i = 0; i < Count; i++)
            {
                if ((data[i] == null && value == null) || (data[i] != null && value != null && data[i].Equals(value)))
                {
                    return i;
                }
            }
            return -1;
        }

        public object[] ToArray()
        {
            if (Count == 0)
            {
                return emptyArray;
            }

            object[] array = new object[Count];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = data[i];
            }
            return array;
        }

        public void Reverse()
        {
            object first;
            object last;
            for (int i = 0; i < Count / 2; i++)
            {
                first = data[i];
                last = data[Count - i - 1];
                data[i] = last;
                data[Count - i - 1] = first;
            }
        }
    }
}
