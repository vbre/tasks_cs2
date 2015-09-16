using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeterinaryValeriya
{
    enum TypeOfAnimal
    {
        Cat,
        Dog,
        Hamsted,
        Fish,
    }

    class Program
    {
        static ClinicRegistry AnimalRegistry = new ClinicRegistry();

        static void Main(string[] args)
        {
            Menu mainMenu = new Menu(
            new List<Menu.MenuItem> {
               new Menu.MenuItem { Label = "About company", ActionToDo = ShowAboutCompany },
               new Menu.MenuItem { Label = "Put new animal in clinic", ActionToDo = PutAnimalInClinic },
               new Menu.MenuItem { Label = "Examinate animal", ActionToDo = ExaminteReaction },
               //new Menu.MenuItem { Label = "Show list of animals", ActionToDo =  }
               new Menu.MenuItem { Label = "Remove animal", ActionToDo = RemoveAnimal }
               new Menu.MenuItem { Label = "Quit", ActionToDo = null }
            });

            Console.WriteLine("[H] About company\n[R] Put new animal in clinic\n[E]Examinate animal\n[L] Show list of animals\n[D] Remove animal\n[Q] Quit\n");
            string menuChoise = "";
            
            do
            {
                menuChoise = Console.ReadLine();

                else if (menuChoise.ToUpper() == "L")
                {
                    PrintListOfAnimals(AnimalRegistry);
                }
                else if (menuChoise.ToUpper() == "D")
                {
                    Console.WriteLine("Input animal's ID:");
                    int ID;
                    Int32.TryParse(Console.ReadLine(), out ID);
                    AnimalRegistry.RemoveAnimal(ID);
                }
            } while (menuChoise.ToUpper() != "Q");

            Environment.Exit(0);
            Console.ReadKey();
        }

        static void PrintListOfAnimals (ClinicRegistry inputRegistry)
        {
            Console.WriteLine("\n-----List of animals-----");
            for (int i = 0; i < inputRegistry.Count; i++)
            {
                Console.WriteLine(inputRegistry[i].ToString());
            }
        }

        static void PrintEnumOfAnimalTypes()
        {
            Console.WriteLine("<0> for {0}", TypeOfAnimal.Cat.ToString());
            Console.WriteLine("<1> for {0}", TypeOfAnimal.Dog.ToString());
            Console.WriteLine("<2> for {0}", TypeOfAnimal.Hamsted.ToString());
            Console.WriteLine("<3> for {0}", TypeOfAnimal.Fish.ToString());
            Console.WriteLine();
        }

        public char GetUserInput()
        {
            return Console.ReadLine()[0];
        }

        private static void ShowAboutCompany ()
        {
            Console.WriteLine("This is veterinary clinic for domestic animals:)");
        }

        private static void PutAnimalInClinic()
        {
            Console.WriteLine("Input animal name:");
            string nameOfAnimal = Console.ReadLine();
            Console.WriteLine("\nPlease, input age of animal");
            int ageOfAnimal;
            Int32.TryParse(Console.ReadLine(), out ageOfAnimal);
            int inputTypeOfanimal;
            Console.WriteLine("Input type of animal from the list below:\n");
            PrintEnumOfAnimalTypes();
            Int32.TryParse(Console.ReadLine(), out inputTypeOfanimal);
            DomesticAnimal newAnimal = null;
            switch (inputTypeOfanimal)
            {
                case 0:
                    newAnimal = new Cat(nameOfAnimal, ageOfAnimal);
                    break;
                case 1:
                    newAnimal = new Dog(nameOfAnimal, ageOfAnimal);
                    break;
                case 2:
                    newAnimal = new Hamsted(nameOfAnimal, ageOfAnimal);
                    break;
                case 3:
                    newAnimal = new Fish(nameOfAnimal, ageOfAnimal);
                    break;
                default:
                    throw ApplicationException("Unfortunately, our clinic doesn't take care of such animals");
                    break;
            }

           AnimalRegistry.AddAnimal(newAnimal);
        }

        private static void ExaminteReaction ()
        {
            for (int i = 0; i < AnimalRegistry.Count; i++)
            {
                AnimalRegistry[i].ExamReaction();
            }
        }

        private static void RemoveAnimal ()
        {
            Console.WriteLine("Input animal's ID:");
            int ID;
            Int32.TryParse(Console.ReadLine(), out ID);
            AnimalRegistry.RemoveAnimal(ID);
        }
    }
}
