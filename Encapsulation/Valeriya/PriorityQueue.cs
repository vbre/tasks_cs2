using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation.Valeriya
{
    class PriorityQueue : Encapsulation.IPriorityQueue <T>
    {
        List<Tuple<int, T>> priorityQueue = new List<Tuple<int, T>>;
        public int Count
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public T Dequeue()
        {
            throw new NotImplementedException();
        }

        public void Enqueue(T val, int priority)
        {
            throw new NotImplementedException();
        }

        public T First()
        {
            throw new NotImplementedException();
        }

        public T First(int priority)
        {
            throw new NotImplementedException();
        }

        public int GetCount(int priority)
        {
            throw new NotImplementedException();
        }

        public T Last()
        {
            throw new NotImplementedException();
        }

        public T Last(int priority)
        {
            throw new NotImplementedException();
        }
    }
}
