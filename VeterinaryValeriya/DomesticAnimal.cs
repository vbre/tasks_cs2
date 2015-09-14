using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeterinaryValeriya
{
    abstract class DomesticAnimal
    {
        protected string Name
        {
            get; set;
        }

        protected int Age
        {
            get; set;
        }

        public abstract void ExamReaction();

        public DomesticAnimal (string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
}
