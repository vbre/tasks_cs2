using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation.Alina
{
    abstract class Number<T>
    {
        protected T value;
        public T Value { get { return value; } }
        public Number()
        {

        }
        public Number(T val)
        {
            this.value = val;
        }
        public abstract T Add(T op1);
    }
}
