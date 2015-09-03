using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation.Alina
{
    class Double: Number<double>
    {
        double Add(double op1)
        { return value + op1; }
    }
}
