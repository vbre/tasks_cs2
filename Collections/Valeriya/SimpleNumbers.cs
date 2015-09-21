using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections.Valeriya
{
    class SimpleNumbers : ISimpleNumbers
    {
        private int topBorder;
        private List<int> simpleNumbersList = new List<int>();

        public SimpleNumbers(int top)
        {
            topBorder = top;

            for (int i = 2; i <= top; i++)
            {
                if (IsNumberSimple(i))
                {
                    simpleNumbersList.Add(i);
                }
            }
        }

        private bool IsNumberSimple(int inputNumber)
        {
            bool result = false;

            for (int i = 2; i <= (inputNumber / 2); i++)
            {
                if (inputNumber % i == 0)
                {
                    result = false;
                    break;
                }
            }

            result = true;

            return result;
        }

        public IEnumerator<int> GetEnumerator()
        {
            return (IEnumerator<int>)new SNSequence(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class SNSequence : IEnumerator
        {
            private int position = -1;
            private SimpleNumbers instance;

            object IEnumerator.Current
            {
                get
                {
                    return Current;
                }
            }

            public SNSequence(SimpleNumbers instance)
            {
                this.instance = instance;
            }

            public bool MoveNext()
            {
                position++;
                return (position < instance.simpleNumbersList.Count);
            }

            public void Reset()
            {
                position = -1;
            }

            public int Current
            {
                get { return instance.simpleNumbersList[position]; }
            }
        }
    }
}
