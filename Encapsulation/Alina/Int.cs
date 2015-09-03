using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation.Alina
{
    class Int: Number<int>
    {
        int Add(int op1)
        { return value + op1; }
    }
}
