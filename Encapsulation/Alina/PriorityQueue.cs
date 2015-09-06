using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation.Alina
{
    class PriorityQueue <T> : IPriorityQueue<T>
    {
        SortedDictionary<int, Queue<T>> myQueue = new SortedDictionary<int, Queue<T>>();
        public void Enqueue(T val, int priority)
        {
            if (!myQueue.ContainsKey(priority))
            {
                myQueue.Add(priority, new Queue<T>());
            }
            myQueue[priority].Enqueue(val);
        }

        public T Dequeue()
        {
            return myQueue.First().Value.Dequeue();
        }

        public T First()
        {
            return myQueue.First().Value.Peek();
        }

        public T First(int priority)
        {
            if (!myQueue.ContainsKey(priority) || myQueue[priority].Count == 0)
            {
                throw new Exception("There is no value with such priority");
            }
            return myQueue[priority].Peek();
        }

        public T Last()
        {
            return myQueue.Last().Value.ElementAt(myQueue.Last().Value.Count-1);
        }

        public T Last(int priority)
        {
            if (!myQueue.ContainsKey(priority) || myQueue[priority].Count == 0)
            {
                throw new Exception("There is no value with such priority");
            }
            return myQueue[priority].Last();
        }

        public int Count
        {
            get { return myQueue.Values.Sum(q => q.Count); }
        }

        public int GetCount(int priority)
        {
           return myQueue[priority].Count;
        }
    }
}
