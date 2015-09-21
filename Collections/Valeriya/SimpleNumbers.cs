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

        public SimpleNumbers (int top)
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

        private class SNSequence : IEnumerable
        {
            private int currNumber = 0;
            private SimpleNumbers instance;

            public SNSequence (SimpleNumbers instance)
            {
                this.instance = instance;
            }

            int MoveNext (int currNumber)
            {
                this.currNumber = currNumber;
                return simpleNumbersList.FindIndex((index) => { if (simpleNumbersList.Contains(currNumber) return ) });
            }

            int Reset()
            {

            }

            int CurrentNumber ()
            {

            }

            public IEnumerator GetEnumerator()
            {
                throw new NotImplementedException();
            }
        }

        public IEnumerator<int> GetEnumerator()
        {
            
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
