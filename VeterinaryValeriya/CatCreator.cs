using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeterinaryValeriya
{
    class CatCreator : IAnimalCreator
    {
        public DomesticAnimal CreateAnimal(string name, int age)
        {
            return new Cat(name, age);
        }
    }
}
