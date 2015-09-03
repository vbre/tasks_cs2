using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation.Alina
{
    class EncapsulationExercises : IEncapsulationExercises
    {
        public void MoneyMoney()
        {
            Money m1 = new Money(25, 51);
            Money m2 = new Money(1, 58);
            Money m3 = new Money(1005);
            int hrivnas = m1.Hrivnas;
            Console.WriteLine("{0} грн", hrivnas);
            int kopecs = m1.Kopeks;
            Console.WriteLine("{0} коп", kopecs);
            int hrivnas2 = m2.Hrivnas;
            Console.WriteLine("{0} грн", hrivnas2);
            int kopecs2 = m2.Kopeks;
            Console.WriteLine("{0} коп", kopecs2);
            int hrivnas3 = m3.Hrivnas;
            Console.WriteLine("{0} грн", hrivnas3);
            int kopecs3 = m3.Kopeks;
            Console.WriteLine("{0} коп", kopecs3);
            Money m4 = m2 + m3;
            Console.WriteLine(m4.ToString());
            Money m5 = m1 - m3;
            Console.WriteLine(m5.ToString());
            Money m6 = m1 * 2;
            Console.WriteLine(m6.ToString());
            Money m7 = m3 / 5;
            Console.WriteLine(m7.ToString());
            bool m8 = m1 == m2;
            Console.WriteLine(m8);
            bool m9 = m1 != m2;
            Console.WriteLine(m9);
            bool m10 = m1 > m2;
            Console.WriteLine(m10);
            bool m11 = m1 < m2;
            Console.WriteLine(m11);
            Money m12 = Money.Clone(m2);
            Console.WriteLine(m12);

//------------------------------------------------------------------
//          class Matrix

            Matrix matrix1 = new Matrix(3, 3);
            Matrix matrix2 = new Matrix(3, 3);
            Matrix matrix3 = matrix1 + matrix2;
            Matrix matrix4 = matrix1 - matrix2;
            Matrix matrix5 = matrix1 * 5;
            matrix5.PrintMatrix(matrix2);

            Console.ReadKey();

        }
    }
}
