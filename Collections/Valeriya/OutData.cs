using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections.Valeriya
{
    class OutData : IOutData
    {
        public int Code { get; }
        public double Average { get; }
        public OutData (int code, double average)
        {
            this.Code = code;
            this.Average = average;
        }
    }
}
