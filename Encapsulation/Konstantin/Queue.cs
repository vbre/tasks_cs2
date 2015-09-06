using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation.Konstantin
{
    class Queue<T>: IPriorityQueue<T>
    {
        private List<LinkedList<T>> internalData = new List<LinkedList<T>>(); 

        public void Enqueue(T val, int priority)
        {
            if (internalData.Count<priority)
            {
                for (int i = internalData.Count; i < priority; i++)
                {
                    internalData.Add(new LinkedList<T>());
                }
            }
            internalData[priority].AddLast(val);
        }

        public T Dequeue()
        {
            T firstVal;           
            if (internalData[0].Count==0)
            {
                internalData.RemoveAt(0);
            }
            firstVal = First();
            internalData[0].RemoveFirst();
            return firstVal;
        }

        public T First()
        {
            return internalData[0].First();
        }

        public T First(int priority)
        {
            return internalData[priority].First();
        }

        public T Last()
        {
            return internalData.Last().Last();
        }
        public T Last(int priority)
        {
            return internalData[priority].Last();
        }

        public int Count
        {
            get
            {
                int count = 0;
                for (int i = 0; i < internalData.Count; i++)
                {
                    count += internalData[i].Count;
                }
                return count;
            }
        }

        public int GetCount(int priority)
        {
            return internalData[priority].Count;
        }
    }
}
