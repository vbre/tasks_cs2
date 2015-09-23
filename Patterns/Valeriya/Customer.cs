
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Valeriya
{
    class Customer: ISubscriber
    {
        private string name;

        public string Name { get { return name; }
            set
            {
                if (value != "")
                    name = value;
            }
        }

        public void ReactOnGoodArrival ()
        {
            Console.WriteLine("Customer reaction on good's arrval");
        }

        public void ReactOnClosing ()
        {
            Console.WriteLine("Customer reaction on shop's closing");
        }

        public Customer(string name)
        {
            Name = name;
        }
    }
}
