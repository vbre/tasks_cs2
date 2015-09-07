using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation.Konstantin
{
    class EncapsulationExercises : IEncapsulationExercises
    {
        public void MoneyMoney()
        {
            Money m1 = new Money();
            Money m2 = new Money(25,51);
            Money m3 = new Money(768);

            int hrivnas = m1.Hrivnas;
            int kopecks = m1.Kopecks;

            Money m4 = m1 + m3;
            int totalKopecs = (int)m2;
            float someMoney = (float)m2;
            string moneyString = (string)m2;
        }


        public void WorkPriorityQueue()
        {
            throw new NotImplementedException();
        }
    }
}
