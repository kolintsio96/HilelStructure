﻿using Interface;
namespace Library
{
    public class List<T> : Interface.IList<T>
    {
        private T[] data;
        public int Capacity { get; private set; } = 4;
        private T[] emptyArray = Array.Empty<T>();

        public int Count { get; private set; } = 0;

        public List()
        {
            data = new T[Capacity];
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
                data = new T[capacity];
            }
        }

        public T this[int index]
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
        
        public void Add(T value)
        {
            Count++;
            T[] array = data;

            if (Count > Capacity)
            {
                Capacity = Count * 2;
                data = new T[Capacity];

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

        public void Insert(int index, T value)
        {
            if (index < 0 || index > Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            bool inserted = false;
            Count++;

            T[] array = new T[Capacity];
            data.CopyTo(array, 0);

            if (Count > Capacity)
            {
                Capacity = Count;
                data = new T[Capacity];
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
        
        public void Remove(T value)
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

            T[] array = data;

            data = new T[Capacity];

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

        public bool Contains(T value)
        {
            return IndexOf(value) != -1;
        }

        public int IndexOf(T value) {
            for (int i = 0; i < Count; i++)
            {
                if ((data[i] == null && value == null) || (data[i] != null && value != null && data[i].Equals(value)))
                {
                    return i;
                }
            }
            return -1;
        }

        public T[] ToArray()
        {
            if (Count == 0)
            {
                return emptyArray;
            }

            T[] array = new T[Count];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = data[i];
            }
            return array;
        }

        public void Reverse()
        {
            T first;
            T last;
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
