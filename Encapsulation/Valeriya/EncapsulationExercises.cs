using System;

namespace Encapsulation.Valeriya
{
    class EncapsulationExercises : IEncapsulationExercises
    {
        public void MoneyMoney()
        {
            Money m = new Money(1018);
            Money m1 = new Money(26,56);
            Money m2 = new Money(1, 58);
            Money m3 = m1 + m2;
            //Console.WriteLine("string: {0}", m1.ToString());
            //Console.WriteLine("int: {0}", (int)m1);
            //Console.WriteLine("float: {0}", (float)m1);
            //Console.WriteLine(m3);
            //Console.WriteLine("------------SquarredMatrix------------");
            SquarredMatrix matrix1 = new SquarredMatrix(3);
            SquarredMatrix matrix2 = new SquarredMatrix(3);
            SquarredMatrix matrix3 = matrix1 + matrix2;
            SquarredMatrix.PrintMatrix(matrix1);
            SquarredMatrix.PrintMatrix(matrix2);
            SquarredMatrix.PrintMatrix(matrix3);
            Console.ReadKey();
        }
    }
}
