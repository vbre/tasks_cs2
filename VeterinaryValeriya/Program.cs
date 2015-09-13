using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeterinaryValeriya
{
    class Program
    {
        static void Main(string[] args)
        {
            ClinicRegistry AnimalRegistry = new ClinicRegistry();

            Console.WriteLine("[H] About company\n[R] Put new animal in clinic\n[L] Show list of animals\n[D] Discharge animal\n[Q] Quit\n");
            string menuChoise = "";

            do
            {
                menuChoise = Console.ReadLine();

                if (menuChoise.ToUpper() == "H")
                {
                    Console.WriteLine("This is veterinary clinic for domestic animals:)");
                }
                else if (menuChoise.ToUpper() == "R")
                {
                    Console.WriteLine("Input animal name:");
                    string name = Console.ReadLine();
                    Console.WriteLine("\nPlease, input disease from the list below:\n{0}\n{1}\n{2}\n", Disease.Cancer, Disease.Cold, Disease.Diarrhea, Disease.Fracture);
                    string inputDisease = Console.ReadLine();
                    DomesticAnimal newAnimal = new DomesticAnimal(name, inputDisease);
                    AnimalRegistry.AddAnimal(newAnimal);
                }
                else if (menuChoise.ToUpper() == "L")
                {
                    PrintListOfAnimals(AnimalRegistry);
                }
                else if (menuChoise.ToUpper() == "D")
                {
                    Console.WriteLine("Input number of animal:");
                    int number;
                    Int32.TryParse(Console.ReadLine(), out number);
                    AnimalRegistry.RemoveAnimal(number);
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
                Console.WriteLine(inputRegistry[i]);
            }
        }
    }
}
