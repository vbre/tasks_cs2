using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeterinaryValeriya
{
    class DogCreator: IDogCreator
    {
        public Dog CreateDog(string name, int age)
        {
            return new Dog(name, age);
        }
    }
}
