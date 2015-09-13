using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeterinaryValeriya
{
    enum Disease
    {
        Cold,
        Cancer,
        Diarrhea,
        Fracture
    }

    class DomesticAnimal
    {
        public string name
        {
            get; set;
        }

        public string disease
        {
            get; set;
        }

        public DomesticAnimal (string name, string disease)
        {
            this.name = name;
            this.disease = disease;
        }
    }
}
