using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation.Alina
{
    class ComplexNumbers
    {
        int real;
        int imaginary;
        public ComplexNumbers(int real, int imaginary)
        {
            this.real = real;
            this.imaginary = imaginary;
        }
        int Real { get { return real; } }
        int Imaginary { get { return imaginary; } }
        public static ComplexNumbers operator+(ComplexNumbers operand1, ComplexNumbers operand2)
        {
            return null;
        }           
    }
}
