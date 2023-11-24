namespace Library
{
    public struct List
    {
        private object[] data;
        private object[] emptyArray = new object[0];

        public int Count { get { return data.Length; } }

        public List()
        {
            data = emptyArray;
        }
        
        public List(int capacity)
        {
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
                return data[index];
            }

            set
            {
                data[index] = value;
            }
        }
        
        public void Add(object value)
        {
            int size = data.Length + 1;

            object[] array = data;
        
            data = new object[size];

            for (int i = 0; i < size; i++) {
                if (i == size - 1)
                {
                    data[i] = value;
                } else
                {
                    data[i] = array[i];
                }

            }
        }

        public void Insert(int index, object value)
        {
            if (index < 0 || index > data.Length)
            {
                throw new ArgumentOutOfRangeException();
            }

            bool inserted = false;

            int size = data.Length + 1;

            object[] array = data;

            data = new object[size];

            for (int i = 0; i < size; i++)
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
            if (index < 0 || index > data.Length - 1)
            {
                throw new ArgumentOutOfRangeException();
            }

            bool skipped = false;

            int size = data.Length - 1;

            object[] array = data;

            data = new object[size];

            for (int i = 0; i < size + 1; i++)
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
        }

        public bool Contains(object value)
        {
            return IndexOf(value) != -1;
        }

        public int IndexOf(object value) {
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].ToString() == value.ToString())
                {
                    return i;
                }
            }
            return -1;
        }

        public object[] ToArray()
        {
            if (data.Length == 0)
            {
                return emptyArray;
            }

            object[] array = new object[data.Length];
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
            for (int i = 0; i < data.Length / 2; i++)
            {
                first = data[i];
                last = data[data.Length - i - 1];
                data[i] = last;
                data[data.Length - i - 1] = first;
            }
        }
    }
}
