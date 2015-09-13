using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation.Vladimir
{
    class PriorityQueue<T> //: ICollection<Tuple<int,T>>
    {
        SortedList<int, Queue<T>> priorityQueue = new SortedList<int, Queue<T>>();
        
        private T first;
        private T last;
        
        public void Enqueue(T value, int priority)
        {
            if (!priorityQueue.ContainsKey(priority))
            {
                if (priorityQueue.Count == 0)
                {
                    first = value;
                }

                priorityQueue.Add(priority, new Queue<T>());
                priorityQueue[priority].Enqueue(value);
                                        
            }
            else
            {
                priorityQueue[priority].Enqueue(value);
            }
            
            last = value;
        }

        public T Dequeue()
        {
            int maxKey = 0;
            for (int i = 0; i < priorityQueue.Count; i++)
            {
                if (!priorityQueue.ContainsKey(maxKey))
                {
                    maxKey++;
                }
            }
            return priorityQueue[maxKey].Dequeue();  
        }

        public T First()
        {
            return first;
        }

        public T First(int priority)
        {
            return priorityQueue[priority].Peek();  
        }

        public T Last()
        {
            return last;
        }

        public T Last(int priority)
        {
            return priorityQueue[priority].Last();
        }

        public int GetCount(int priority)
        {
            return priorityQueue[priority].Count(); 
        }


        public void Add(Tuple<short, T> item)
        {
            
            if (!priorityQueue.ContainsKey(item.Item1))
            {
                priorityQueue.Add(item.Item1, new Queue<T>());
                priorityQueue[item.Item1].Enqueue(item.Item2);
            }
            else
            {
                priorityQueue[item.Item1].Enqueue(item.Item2);
            }
        }
        //-------------------------------------
        public void Clear()
        {
           priorityQueue.Clear();
        }


        public bool Contains(Tuple<int, T> item)
        {       
            return (priorityQueue[item.Item1].Contains(item.Item2)) ? true : false; 
        }

        public void CopyTo(Tuple<int, T>[] array, int arrayIndex)
        {
           throw new NotImplementedException();
        }

        public int Count
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsReadOnly
        {
            get { throw new NotImplementedException(); }
            //return (priorityQueue.IsReadOnly) ? true : false; 

        }

        public bool Remove(Tuple<int, T> item)
        {
            throw new NotImplementedException();
            //return (priorityQueue[item.Item1].Remove(item.Item2)) ? true : false;

        }

        public IEnumerator<Tuple<int, T>> GetEnumerator()
        {
            throw new NotImplementedException();

        //     return this.priorityQueue.GetEnumerator();

        }

        
    }

    //public class PeopleEnum : IEnumerator
    //{
    //    public Person[] _people;

    //    // Enumerators are positioned before the first element
    //    // until the first MoveNext() call.
    //    int position = -1;

    //    public PeopleEnum(Person[] list)
    //    {
    //        _people = list;
    //    }

    //    public bool MoveNext()
    //    {
    //        position++;
    //        return (position < _people.Length);
    //    }

    //    public void Reset()
    //    {
    //        position = -1;
    //    }

    //    object IEnumerator.Current
    //    {
    //        get
    //        {
    //            return Current;
    //        }
    //    }

    //    public Person Current
    //    {
    //        get
    //        {
    //            try
    //            {
    //                return _people[position];
    //            }
    //            catch (IndexOutOfRangeException)
    //            {
    //                throw new InvalidOperationException();
    //            }
    //        }
    //    }
    //}

}
