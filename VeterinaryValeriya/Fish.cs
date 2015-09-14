using System;

namespace VeterinaryValeriya
{
    class Fish: DomesticAnimal
    {
        public Fish(string name, int age) : base(name, age)
        {
            Name = name;
            Age = age;
        }

        public override void ExamReaction()
        {
            Console.WriteLine("Fish {0} has slipped:(", Name);
        }
    }
}
