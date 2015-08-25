using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays2.Elena
{
    class ArraysJob : IArraysJob
    {
        public bool JaggedArrayExchange(int[][] inputArray)
        {
            int firstLineLenth = inputArray[0].Length;
            bool thereIsLine = false;

            for (int i = 1; i < inputArray.Length; i++)
            {
                if (firstLineLenth == inputArray[i].Length)
                {
                    int numberSerchLine = i;
                    int[] chengeArrey = new int[firstLineLenth];
                    for (int j = 0; j < firstLineLenth; j++)
                    {
                        chengeArrey[j] = inputArray[0][j];
                        inputArray[0][j] = inputArray[numberSerchLine][j];
                        inputArray[numberSerchLine][j] = chengeArrey[j];

                    }
                    thereIsLine = true;
                    break;
                }
            }

            return thereIsLine;
        }

        public int[][] LifeCalculations(int[][] inputArray)
        {
            int firstIzmerenie = inputArray.Length;
            int secondIzmerenie = inputArray[0].Length;
            int sum;
            int[][] newAray = new int[firstIzmerenie][];

            
            for (int i = 0; i < firstIzmerenie; i++)
            {
                newAray[i] = new int[secondIzmerenie];
                for (int j = 0; j < secondIzmerenie; j++)
                {
                    try
                    {
                        if (j == 0)
                        {
                            if (i == 0)
                            { sum = inputArray[i][j + 1] + inputArray[i + 1][j] + inputArray[i + 1][j + 1]; }

                            else if (i == firstIzmerenie - 1)
                            { sum = inputArray[i - 1][j] + inputArray[i][j + 1] + inputArray[i - 1][j + 1]; }

                            else
                            {
                                sum = inputArray[i - 1][j] + inputArray[i - 1][j + 1] + inputArray[i][j + 1] + inputArray[i + 1][j] + inputArray[i + 1][j + 1];
                            }
                        }

                        else if (j == secondIzmerenie - 1)
                        {
                            if (i == 0)
                            { sum = inputArray[i][j - 1] + inputArray[i + 1][j - 1] + inputArray[i + 1][j]; }

                            else if (i == firstIzmerenie - 1)
                            { sum = inputArray[i - 1][j - 1] + inputArray[i - 1][j] + inputArray[i][j - 1]; }

                            else
                            {
                                sum = inputArray[i - 1][j - 1] + inputArray[i - 1][j] + inputArray[i][j - 1] + inputArray[i + 1][j - 1] + inputArray[i + 1][j];
                            }
                        }

                        else
                        {
                            if (i == 0)
                            {
                                sum = inputArray[i][j - 1] + inputArray[i][j + 1] + inputArray[i + 1][j - 1] + inputArray[i + 1][j] + inputArray[i + 1][j + 1];
                            }

                            else if (i == firstIzmerenie - 1)
                            {
                                sum = inputArray[i][j - 1] + inputArray[i][j + 1] + inputArray[i - 1][j - 1] + inputArray[i - 1][j] + inputArray[i - 1][j + 1];
                            }
                            else
                            {
                                sum = inputArray[i - 1][j - 1] + inputArray[i - 1][j] + inputArray[i - 1][j + 1] +
                                    inputArray[i][j - 1] + inputArray[i][j + 1] +
                                    inputArray[i + 1][j - 1] + inputArray[i + 1][j] + inputArray[i + 1][j + 1];
                            }

                        }


                        if (inputArray[i][j] == 1 && (sum > 3 || sum < 2))
                        {
                            newAray[i][j] = 0;
                        }

                        else if (inputArray[i][j] == 0 && sum == 3)
                        {
                            newAray[i][j] = 1;
                        }
                        else
                        {
                            newAray[i][j] = inputArray[i][j];
                        }
                    }
                    catch (Exception ex) { string o = ex.ToString(); }

                }
            }

            return newAray;
        }

        public int CalculateEqualPairs(int[] inputArray)
        {
            int countOfCouple = 0;

            for (int i = 0; i < inputArray.Length - 1; i++)
            {
                if (inputArray[i] == inputArray[i + 1])
                {
                    countOfCouple++;
                }
            }

            return countOfCouple;
        }
    }
}
