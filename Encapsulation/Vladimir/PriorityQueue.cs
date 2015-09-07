using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation.Vladimir
{
    class PriorityQueue<T> :ICollection<Tuple<Int16,T>>
    {
        SortedList<int, Queue<T>> priorityQueue = new SortedList<int, Queue<T>>();
        
        //private int priority;
        private T first;
        private T last;
        
        public void Enqueue(T value, int priority)
        {
            if (!priorityQueue.ContainsKey(priority))
            {
                priorityQueue.Add(priority, new Queue<T>());
                priorityQueue[priority].Enqueue(value);
                
                if (first == null)
                {
                    first = value;
                }                        
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

        //public int Count
        //{ get; }

        public int GetCount(int priority)
        {
            //throw new NotImplementedException();
            return priorityQueue[priority].Count(); 
        }


        public void Add(Tuple<short, T> item)
        {
            //throw new NotImplementedException();
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

        public void Clear()
        {
           priorityQueue.Clear();
        }


        public bool Contains(Tuple<short, T> item)
        {
            //throw new NotImplementedException();
            return (priorityQueue[item.Item1].Contains(item.Item2)) ? true : false; 
        }

        public void CopyTo(Tuple<short, T>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
           // ? priorityQueue[item.Item1].CopyTo(item.Item2)


        }

        public int Count
        {
            get { throw new NotImplementedException(); }
            //get { ; }
            //return priorityQueue.Count();

        }

        public bool IsReadOnly
        {
            get { throw new NotImplementedException(); }


        }

        public bool Remove(Tuple<short, T> item)
        {
            throw new NotImplementedException();


        }

        public IEnumerator<Tuple<short, T>> GetEnumerator()
        {
            throw new NotImplementedException();

        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
