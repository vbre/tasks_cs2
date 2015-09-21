using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeterinaryValeriya
{
    class FishCreator: IAnimalCreator
    {
        public DomesticAnimal CreateAnimal(string name, int age)
        {
            return new Fish(name, age);
        }
    }
}
