
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

        public void ReactOnGoodArrivalIgnore ()
        {
            Console.WriteLine("Customer ignored good's arrival");
        }

        public void ReactOnGoodArrivalBuy ()
        {
            Console.WriteLine("Customer bought arrived good");
        }

        public void ReactOnGoodArrivalUnSubscribe ()
        {
            Console.WriteLine("Customer unsubscribed");
        }

        public Customer(string name)
        {
            Name = name;
        }
    }
}
