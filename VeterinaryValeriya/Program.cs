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
        Fish
    }

    class Program
    {
        private static Menu mainMenu = new Menu (

           new List<Menu.MenuItem> {
               new Menu.MenuItem { Code = 'H' , Label = "[H]elp", ActionToDo = ShowAboutCompany },
               new Menu.MenuItem { Code = 'P' , Label = "[P]ut new animal in clinic", ActionToDo = PutAnimalInClinic },
               new Menu.MenuItem { Code = 'E' , Label = "[E]xaminate animal", ActionToDo = ExaminteReaction },
               new Menu.MenuItem { Code = 'S' , Label = "[S]how list of animals", ActionToDo = PrintListOfAnimals },
               new Menu.MenuItem { Code = 'R' , Label = "[R]emove animal", ActionToDo = RemoveAnimal },
               new Menu.MenuItem { Code = 'Q' , Label = "[Q]uit", ActionToDo = () => { Environment.Exit(0); } }
           });

        static CatCreator CatFactory = new CatCreator();
        static DogCreator DogFactory = new DogCreator();
        static HamstedCreator HamstedFactory = new HamstedCreator();
        static FishCreator FishFactory = new FishCreator();

        static void Main(string[] args)
        {
            PrintMenu();
            char inputCode;
            do
            {
                inputCode = GetUserInput();
                mainMenu.HandleUserInput(inputCode);
                
            } while ( inputCode != 'Q' );

            Console.ReadKey();
        }

        private static void PrintListOfAnimals ()
        {
            Console.WriteLine("\n-----List of animals-----");
            for (int i = 0; i < ClinicRegistry.Instance.Count; i++)
            {
                Console.WriteLine(ClinicRegistry.Instance[i].ToString());
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

        public static char GetUserInput()
        {
            return Console.ReadLine()[0];
        }

        private static void ShowAboutCompany ()
        {
            Console.WriteLine("This is veterinary clinic for domestic animals:)");
        }

        private static void PutAnimalInClinic()
        {
            Console.WriteLine("Input type of animal from the list below:\n");
            PrintEnumOfAnimalTypes();

            int inputTypeOfanimal;

            Int32.TryParse(Console.ReadLine(), out inputTypeOfanimal);

            DomesticAnimal newAnimal = null;

            switch (inputTypeOfanimal)
            {
                case 0:
                    newAnimal = CatFactory.CreateAnimal(GetNameOfAnimalFromConsole(), GetNumberFromConsole("\nPlease input age of animal"));
                    break;
                case 1:
                    newAnimal = DogFactory.CreateAnimal(GetNameOfAnimalFromConsole(), GetNumberFromConsole("\nPlease input age of animal"));
                    break;
                case 2:
                    newAnimal = HamstedFactory.CreateAnimal(GetNameOfAnimalFromConsole(), GetNumberFromConsole("\nPlease input age of animal"));
                    break;
                case 3:
                    newAnimal = FishFactory.CreateAnimal(GetNameOfAnimalFromConsole(), GetNumberFromConsole("\nPlease input age of animal"));
                    break;
                default:
                    Console.WriteLine("Unfortunately, our clinic doesn't take care of such animals");
                    break;
            }

           ClinicRegistry.Instance.AddAnimal(newAnimal);
        }

        private static void ExaminteReaction ()
        {
            for (int i = 0; i < ClinicRegistry.Instance.Count; i++)
            {
                ClinicRegistry.Instance[i].ExamReaction();
            }
        }

        private static void RemoveAnimal ()
        {
            Console.WriteLine("Input animal's ID:");
            int ID;
            Int32.TryParse(Console.ReadLine(), out ID);
            ClinicRegistry.Instance.RemoveAnimal(ID);
        }

        public static int GetNumberFromConsole (string msg)
        {
            int correctResult = 0;
            int ageOfAnimal;
            Console.WriteLine(msg);
            Int32.TryParse(Console.ReadLine(), out ageOfAnimal);
                
            do
            {
                if (ageOfAnimal > 0)
                {
                    correctResult = ageOfAnimal;
                }
                else
                {
                    Console.WriteLine("Please, input correct data");
                }

                Int32.TryParse(Console.ReadLine(), out ageOfAnimal);

            } while (ageOfAnimal <= 0);

            return correctResult;
        }

        public static void PrintMenu()
        {
            foreach (Menu.MenuItem elem in mainMenu)
            {
                Console.WriteLine("{0} - {1}", elem.Code, elem.Label);
            }

            Console.WriteLine();
        }

        public static string GetNameOfAnimalFromConsole()
        {
            Console.WriteLine("\nInput animal name:");
            return Console.ReadLine();
        }
    }
}
