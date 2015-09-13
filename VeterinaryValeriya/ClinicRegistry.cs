using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeterinaryValeriya
{
    class ClinicRegistry
    {
        private static Dictionary<int, DomesticAnimal> registry;

        private static int countOfAnimals = 0;

        private static int CreateID()
        {
            return countOfAnimals++;
        }

        public void AddAnimal (DomesticAnimal animal)
        {
            registry.Add(CreateID(), animal);
        }

        public void RemoveAnimal (int ID)
        {
            registry.Remove(ID);
        }

        public int Count
        {
            get { return registry.Count; }
        }

        public Tuple<string, string> this[int elem]
        {
            get { return Tuple.Create(registry[elem].name, registry[elem].disease); }
        }

        static ClinicRegistry()
        {
            registry = new Dictionary<int, DomesticAnimal>();
        }
    }
}
