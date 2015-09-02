using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation.Valeriya
{
    class Matrix
    {
        static Random rnd = new Random();
        double[,] matrix = null;
        public Matrix(int sizeOfMatrix)
        {
            matrix = new double[sizeOfMatrix, sizeOfMatrix];

            for (int i = 0; i < sizeOfMatrix; i++)
            {
                for (int j = 0; j < sizeOfMatrix; j++)
                {
                    matrix[i, j] = rnd.Next(-100, 100);
                }
            }
        }

        public Matrix (double[,] matrixInArray)
        {
            matrix  = matrixInArray;
        }

        public Matrix()
        {
            matrix = new double[2, 2];
            matrix[0, 0] = 1;
            matrix[0, 1] = 2;
            matrix[1, 0] = 3;
            matrix[1, 1] = 4;
        }

        public static double[,] MatrixToArray(Matrix operand)
        {
            double[,] result = new double[operand.SizeOfMatrix, operand.SizeOfMatrix];
            result = operand.matrix;
            return result;
        }

        public int SizeOfMatrix
        {
            get { return (int)(Math.Sqrt(matrix.Length)); }
        }

        public static Matrix operator+ (Matrix operand1, Matrix operand2)
        {
            double[,] sumArray = new double[operand1.SizeOfMatrix, operand2.SizeOfMatrix];
            double[,] operand1Array = MatrixToArray(operand1);
            double[,] operand2Array = MatrixToArray(operand2);

            for (int i = 0; i < operand1.SizeOfMatrix; i++)
            {
                for (int j = 0; j < operand2.SizeOfMatrix; j++)
                {
                    sumArray[i, j] = operand1Array[i, j] + operand2Array[i, j];
                }
            }
            Matrix sum = new Matrix(sumArray);
            return sum;
        }

        public static Matrix operator- (Matrix operand1, Matrix operand2)
        {
            double[,] differenceArray = new double[operand1.SizeOfMatrix, operand2.SizeOfMatrix];
            double[,] operand1Array = MatrixToArray(operand1);
            double[,] operand2Array = MatrixToArray(operand2);

            for (int i = 0; i < operand1.SizeOfMatrix; i++)
            {
                for (int j = 0; j < operand2.SizeOfMatrix; j++)
                {
                    differenceArray[i, j] = operand1Array[i, j] - operand2Array[i, j];
                }
            }
            Matrix difference = new Matrix(differenceArray);
            return difference;
        }

        public static Matrix MultiplyWithIdentityMatrix(Matrix inputMatrix)
        {
            return new Matrix(inputMatrix.SizeOfMatrix);
        }

        public static void PrintMatrix(Matrix operand)
        {
            double[,] operandArray = MatrixToArray(operand);

            for (int i = 0; i < operand.SizeOfMatrix; i++)
            {
                for (int j = 0; j < operand.SizeOfMatrix; j++)
                {
                    Console.Write(operandArray[i,j] + " ");
                }
                Console.WriteLine("\n");
            }

            Console.WriteLine("------------------------------");
        }

    }
}
