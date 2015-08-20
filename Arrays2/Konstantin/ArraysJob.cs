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
            int[][] outputArray = new int[inputArray.Length][];
            int[,] tempArray = new int[inputArray.Length+2,inputArray[0].Length+2];
            for (int i = 0; i < inputArray.GetLength(0); i++)
            {
                for (int j = 0; j < inputArray[0].Length; j++)
                {
                    tempArray[i + 1, j + 1] = inputArray[i][j];
                }
            }
            for (int i = 0; i < inputArray.Length; i++)
            {
                outputArray[i] = new int [inputArray[0].Length];
            }
            for (int i = 0; i < inputArray.Length; i++)
            {
                for (int j = 0; j < inputArray[0].Length; j++)
                {
                    if (tempArray[i + 1, j + 1]==1 && (tempArray[i, j]+tempArray[i+1, j]+tempArray[i+2, j]+tempArray[i, j+1]+ tempArray[i+2, j+1]+
                        tempArray[i, j + 2] + tempArray[i + 1, j + 2] + tempArray[i + 2, j + 2]>3||tempArray[i, j]+tempArray[i+1, j]+tempArray[i+2, j]+
                        tempArray[i, j+1]+ tempArray[i+2, j+1]+tempArray[i, j + 2] + tempArray[i + 1, j + 2] + tempArray[i + 2, j + 2]<2))
                    {
                        outputArray[i][j] = 0;
                    }
                    else if (tempArray[i + 1, j + 1]==0 && (tempArray[i, j]+tempArray[i+1, j]+tempArray[i+2, j]+tempArray[i, j+1]+ tempArray[i+2, j+1]+
                        tempArray[i, j + 2] + tempArray[i + 1, j + 2] + tempArray[i + 2, j + 2]==3))
                    {
                        outputArray[i][j] = 1;
                    }
                    else
                    {
                        outputArray[i][j] = inputArray[i][j];
                    }
                }
            }
            return outputArray;
        }

        public int CalculateEqualPairs(int[] inputArray)
        {
            int pairCalculator = 0;
            for (int index = 0; index < inputArray.Length - 1; index++)
            {
                if (inputArray[index] == inputArray[index + 1])
                {
                    pairCalculator++;
                }
            }
            return pairCalculator;
        }
    }
    
}
