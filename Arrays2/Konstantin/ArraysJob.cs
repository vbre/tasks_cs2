using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays2.Konstantin
{
    class ArraysJob : IArraysJob
    {
        public bool JaggedArrayExchange(int[][] inputArray)
        {
            for (int index = 1; index < inputArray.Length; index++)
            {
                if (inputArray[0].Length==inputArray[index].Length)
                {
                    int[] tempArray = inputArray[index];
                    inputArray[index] = inputArray[0];
                    inputArray[0] = tempArray;
                    return true;

                }
            }
            return false;
        }

        public int[][] LifeCalculations(int[][] inputArray)
        {
            int[][] outputArray = new int[inputArray.Length][inputArray[0].Length];
            //int[][] tempArray = new int[inputArray.Length+2][inputArray[0].Length+2];
            for (int i = 0; i < inputArray.GetLength(0)+2; i++)
            {
                
            }
            return outputArray;
        }

        public int CalculateEqualPairs(int[] inputArray)
        {
            int pairCalculator = 0;
            for (int index = 0; index < inputArray.Length-1; index++)
            {
                if (inputArray[index]==inputArray[index+1])
                {
                    pairCalculator++;
                }
            }
            return pairCalculator;
        }
    }
}
