using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeterinaryValeriya
{
    class CatCreator : ICatCreator
    {
        public Cat CreateCat(string name, int age)
        {
            return new Cat(name, age);
        }
    }
}
