
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeterinaryValeriya
{
    class UnknownTypeOfAnimalException: Exception
    {
        public UnknownTypeOfAnimalException(string msg) : base(msg)
        {

        }
    }
}
