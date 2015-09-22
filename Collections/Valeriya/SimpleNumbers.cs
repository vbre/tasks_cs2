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

        public SimpleNumbers(int top)
        {
            topBorder = top;
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

            return result;
        }

        public IEnumerator<int> GetEnumerator()
        {
            return new SNSequence(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class SNSequence : IEnumerator<int>
        {
            private int currNumber = 0;
            private int position = 0;
            private SimpleNumbers instance;

            public SNSequence(SimpleNumbers instance)
            {
                this.instance = instance;
            }

            public bool MoveNext()
            {
                bool result = false;

                while (position < instance.topBorder)
                {
                    if (instance.IsNumberSimple(position + 1))
                    {
                        currNumber = position + 1;
                        result = true;
                        break;
                    }

                    position++;
                }

                return result;
            }

            public void Reset()
            {
                position = 0;
            }

            public void Dispose()
            {
                instance = null;
            }

            public int Current
            {
                get { return currNumber; }
            }

            object IEnumerator.Current
            {
                get
                {
                    return Current;
                }
            }
        }
    }
}
