using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation.Valeriya
{
    class PriorityQueue <T> : Encapsulation.IPriorityQueue <T>
    {
        List<Tuple<int, T>> priorityQueue;

        public PriorityQueue()
        {
            priorityQueue = new List<Tuple<int, T>>();
        }
        
        public Tuple<int, T> this[int elem]
        {
            get { return priorityQueue[elem]; }
            set { priorityQueue[elem] = value; }
        }

        public void Add(int priority, T value)
        {
            priorityQueue.Add(Tuple.Create(priority, value));
        }

        public int Count
        {
            get { return priorityQueue.Count; }
        }

        public T Dequeue()
        {
            T result = GetHighestPriorityElem().Item2;

            if (priorityQueue.Count == 0)
            {
                throw new IndexOutOfRangeException("The queue is empty");
            }
              
            return result;
        }

        public void Enqueue(T val, int priority)
        {
            int index = 0;
            if (priorityQueue.Count == 0)
            {
                throw new IndexOutOfRangeException();
            }
            for (int i = 0; i < priorityQueue.Count; i++)
            {
                if (priorityQueue[i].Item1 > priority)
                {
                    index = i;
                    break;
                }
            }

            priorityQueue.Insert(index, Tuple.Create(priority, val));
        }

        public T First()
        {
            return priorityQueue[0].Item2;
        }

        public T First(int priority)
        {
            T result = priorityQueue[0].Item2;
            for (int i = 0; i < priorityQueue.Count; i++)
            {
                if (priorityQueue[i].Item1 == priority)
                {
                    result = priorityQueue[i].Item2;
                    break;
                }
            }

            return result;
        }

        public int GetCount(int priority)
        {
            int count = 0;
            for (int i = 0; i < priorityQueue.Count; i++)
            {
                if (priorityQueue[i].Item1 == priority)
                {
                    count++;
                }
            }

            return count;
        }

        public T Last()
        {
            return priorityQueue[priorityQueue.Count - 1].Item2;
        }

        public T Last(int priority)
        {
            T result = priorityQueue[0].Item2;
            for (int i = priorityQueue.Count - 1; i >= 0; i--)
            {
                if (priorityQueue[i].Item1 == priority)
                {
                    result = priorityQueue[i].Item2;
                    break;
                }
            }

            return result;
        }

        Tuple<int, T> GetHighestPriorityElem()
        {
            Tuple<int, T> minElemInQueue = priorityQueue[0];
            for (int i = 0; i < priorityQueue.Count; i++)
            {
                if (priorityQueue[i].Item1 < minElemInQueue.Item1)
                {
                    minElemInQueue = priorityQueue[i];
                }
            }

            return minElemInQueue;
        }

        public void PrintQueue ()
        {
            for (int i = 0; i < priorityQueue.Count; i++)
            {
                Console.WriteLine(priorityQueue[i]);
            }
        }
    }
}
