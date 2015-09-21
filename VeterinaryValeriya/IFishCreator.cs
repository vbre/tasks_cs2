using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeterinaryValeriya
{
    interface IFishCreator
    {
        Fish CreateFish(string name, int age);
    }
}
