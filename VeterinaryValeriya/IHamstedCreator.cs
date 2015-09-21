using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeterinaryValeriya
{
    interface IHamstedCreator
    {
        Hamsted CreateHamsted(string name, int age);
    }
}
