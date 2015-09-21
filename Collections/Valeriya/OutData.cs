using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections.Valeriya
{
    class OutData : IOutData
    {
        public int Code { get; private set; }
        public double Average { get; private set; }
        public OutData (int code, double average)
        {
            Code = code;
            Average = average;
        }
    }
}
