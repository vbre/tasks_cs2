using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays2.Valeriya
{
    class ArraysJob : IArraysJob
    {
        public bool JaggedArrayExchange(int[][] inputArray)
        {
            for (int i = 1; i <= inputArray.Length; i++)
            {
                if (inputArray[0].Length == inputArray[i].Length)
                {
                    for (int j = 0; j < inputArray[i].Length; j++)
                    {
                        if (inputArray[0][j] == inputArray[i][j])
                        {
                            continue;
                        }
                        else
                        {
                            break;
                        }

                    }
                    int[] tmp = inputArray[i];
                    inputArray[i] = inputArray[i + 1];
                    inputArray[i + 1] = inputArray[i];
                    return true;
                }
            }

            return false;
        }

        public int[][] LifeCalculations(int[][] inputArray)
        {
            throw new NotImplementedException();
        }

        public int CalculateEqualPairs(int[] inputArray)
        {
            int countOfSameElems = 0;
            for (int i = 0; i < inputArray.Length; i++)
            {
                if (inputArray[i] == inputArray[i + 1])
                {
                    countOfSameElems += 1;
                }
            }

            return countOfSameElems;
        }
    }
}
