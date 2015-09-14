using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeterinaryValeriya
{
    class Hamsted: DomesticAnimal
    {
        public Hamsted(string name, int age) : base(name, age)
        {
            Name = name;
            Age = age;
        }

        public override void ExamReaction()
        {
            Console.WriteLine("Hamsted {0} has run out:(", Name);
        }
    }
}
