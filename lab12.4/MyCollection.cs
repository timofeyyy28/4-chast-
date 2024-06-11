using ClassLibraryLabor10;
using labor121;
using System.Collections;

namespace lab12._4
{
    public class MyCollection<T> : MyList<T>, IEnumerable<T>, IList<T> where T : IInit, ICloneable, new()
    {
        public MyCollection() : base() { }
        public MyCollection(int size) : base(size) { count = size; }
        public MyCollection(T[] collection) : base(collection) { }

        private int count = 0;

        public int Count => count;
        public bool IsReadOnly => false;

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                    throw new ArgumentOutOfRangeException(nameof(index));

                Point<T> current = beg;
                for (int i = 0; i < index; i++)
                {
                    current = current.Next;
                }
                return current.Data;
            }
            set
            {
                if (index < 0 || index >= Count)
                    throw new ArgumentOutOfRangeException(nameof(index));

                Point<T> current = beg;
                for (int i = 0; i < index; i++)
                {
                    current = current.Next;
                }
                current.Data = value;
            }
        }

        public void Add(T item)
        {
            AddToEnd(item);
            count++;
        }

        public int IndexOf(T item)
        {
            Point<T> current = beg;
            for (int i = 0; i < Count; i++)
            {
                if (current.Data.Equals(item))
                    return i;
                current = current.Next;
            }
            return -1;
        }

        public void Insert(int index, T item)
        {
            if (index < 0 || index > Count)
                throw new ArgumentOutOfRangeException(nameof(index));

            if (index == Count)
            {
                AddToEnd(item);
                count++;
                return;
            }

            if (index == 0)
            {
                Point<T> newItem = new Point<T>(item);
                newItem.Next = beg;
                if (beg != null)
                {
                    beg.Pred = newItem;
                }
                else
                {
                    end = newItem;
                }
                beg = newItem;
                count++;
                return;
            }

            Point<T> current = beg;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }

            Point<T> newItemToAdd = new Point<T>(item);
            newItemToAdd.Next = current;
            newItemToAdd.Pred = current.Pred;

            if (current.Pred != null)
            {
                current.Pred.Next = newItemToAdd;
            }
            else
            {
                beg = newItemToAdd;
            }

            current.Pred = newItemToAdd;
            count++;
        }

        public void RemoveAt(int index)
        {
            Console.WriteLine($"Попытка удаления элемента с индексом {index}. Текущий размер коллекции: {count}");

            if (index < 0 || index >= count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Индекс находится вне допустимого диапазона.");
            }

            Point<T> current = beg;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }

            Console.WriteLine($"Удаление элемента: {current.Data}");

            if (current.Pred != null)
            {
                current.Pred.Next = current.Next;
            }
            else
            {
                beg = current.Next;
            }

            if (current.Next != null)
            {
                current.Next.Pred = current.Pred;
            }
            else
            {
                end = current.Pred;
            }

            count--;
            Console.WriteLine($"Элемент удалён. Новый размер коллекции: {count}");
        }

        public bool Contains(T item)
        {
            Point<T> current = beg;
            while (current != null)
            {
                if (current.Data.Equals(item))
                    return true;
                current = current.Next;
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));

            if (arrayIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(arrayIndex));

            if (array.Length - arrayIndex < Count)
                throw new ArgumentException("The number of elements in the source collection is greater than the available space from arrayIndex to the end of the destination array.");

            Point<T> current = beg;
            for (int i = arrayIndex; i < arrayIndex + Count; i++)
            {
                array[i] = current.Data;
                current = current.Next;
            }
        }

        public bool Remove(T item)
        {
            Point<T> current = beg;
            for (int i = 0; i < Count; i++)
            {
                if (current.Data.Equals(item))
                {
                    if (current.Pred != null)
                    {
                        current.Pred.Next = current.Next;
                    }
                    else
                    {
                        beg = current.Next;
                    }

                    if (current.Next != null)
                    {
                        current.Next.Pred = current.Pred;
                    }
                    else
                    {
                        end = current.Pred;
                    }

                    count--;
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new MyEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        internal class MyEnumerator : IEnumerator<T>
        {
            private Point<T> beg;
            private Point<T> current;
            private bool atStart;

            public MyEnumerator(MyCollection<T> collection)
            {
                beg = collection.beg;
                current = null;
                atStart = true;
            }

            public T Current => current.Data;

            object IEnumerator.Current => Current;

            public void Dispose() { }

            public bool MoveNext()
            {
                if (atStart)
                {
                    current = beg;
                    atStart = false;
                }
                else
                {
                    current = current?.Next;
                }
                return current != null;
            }

            public void Reset()
            {
                atStart = true;
                current = null;
            }
        }
    }
}