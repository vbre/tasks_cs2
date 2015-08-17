using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays2.Alina
{
    class ArraysJob : IArraysJob
    {
        public bool JaggedArrayExchange(int[][] inputArray)
        {
            for (int i = 1; i < inputArray.Length; i++)
            {
                if (inputArray[0].Length == inputArray[i].Length)
                {
                    int[] inputArrayCopy = inputArray[0];
                    inputArray[0] = inputArray[i];
                    inputArray[i] = inputArrayCopy;
                    return true;
                }
            }
            return false;
        }

        public int[][] LifeCalculations(int[][] inputArray)
        {
            //создаем массив, который на две строки и на два столбца больше входящего массива;
            int[,] bigArray = new int[inputArray.GetLength(0) + 2, inputArray[0].GetLength(0) + 2];
            //переносим входящий массив внутрь созданного бальшого массива;
            for (int i = 0; i < inputArray.Length; i++)
            {
                for (int j = 0; j < inputArray[i].Length; j++)
                {
                    bigArray[i + 1, j + 1] = inputArray[i][j];
                }
            }
            //проходим маленький массив, который находится внутри большого - для этого используем смещение на 1;
            for (int i = 1; i < bigArray.GetLength(0) - 1; i++)
            {
                for (int j = 1; j < bigArray.GetLength(1) - 1; j++)
                {
                    int sum = bigArray[i - 1, j - 1] + bigArray[i - 1, j] + bigArray[i - 1, j + 1] +
                              bigArray[i, j - 1] + bigArray[i, j + 1] +
                              bigArray[i + 1, j - 1] + bigArray[i + 1, j] + bigArray[i + 1, j + 1];
                    if (bigArray[i, j] == 1)
                    {
                        if (sum > 3 || sum < 2)
                        {
                            bigArray[i, j] = 0;
                        }
                    }
                    else
                    {
                        if (bigArray[i, j] == 3)
                        {
                            bigArray[i, j] = 1;
                        }
                    }

                }
            }
            int[][] outputArray = new int[inputArray.Length][];
            for (int i = 0; i < outputArray.Length; i++)
            {
                outputArray[i] = new int[inputArray[i].Length];
            }
            for (int i = 0; i < bigArray.GetLength(0) - 2; i++)
            {
                for (int j = 0; j < bigArray.GetLength(1) - 2; j++)
                {
                    outputArray[i][j] = bigArray[i + 1, j + 1];
                }
            }

            return outputArray;
        }

        public int CalculateEqualPairs(int[] inputArray)
        {
            int counter = 0;
            for (int i = 0; i < inputArray.Length - 1; i++)
            {
                if (inputArray[i] == inputArray[i + 1])
                {
                    counter++;
                }
            }
            return counter;
        }
    }
}
