using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation.Valeriya
{
    class EncapsulationExercises : IEncapsulationExercises
    {
        public void MoneyMoney()
        {
            Money m = new Money(1018);
            Money m1 = new Money(26,56);
            Money m2 = new Money(1, 58);
            int m3 = m1.Hrivnas + m2.Hrivnas;
        }
    }
}
