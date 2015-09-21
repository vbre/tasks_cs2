using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeterinaryValeriya
{
    class FIshCreator: IFishCreator
    {
        public Fish CreateFish(string name, int age)
        {
            return new Fish(name, age);
        }
    }
}
