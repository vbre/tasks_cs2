using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation.Valeriya
{
    class MyExceptionClass: Exception
    {
        public MyExceptionClass() : base ()
        {
            Console.WriteLine("There is no element with such priority");
        }
    }
}
