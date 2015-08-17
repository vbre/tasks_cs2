using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays2.Vladimir
{
    class ArraysJob : IArraysJob
    {

        public bool JaggedArrayExchange(int[][] inputArray)
        {
            //throw new NotImplementedException();
            // 1
            /// <summary>
            /// Given a two-dimensional array of strings of different lengths. Decide
            /// Whether there is in the array is one more line of the same length, 
            /// As the first line, and if there is, then swap 
            /// All the elements of the first row with all elements of the matched string.
            /// </summary>
            /// <param name="inputArray">входной массив</param>
            /// < returns > returns status: whether the fact of sharing strings </ returns >


            bool answer = false;
            bool[] indexReplacement = new bool[inputArray.Length];

            for (int index = 0; index < inputArray.Length; index++)
            {
                indexReplacement[index] = false;
            }

            for (int index = 0; index < inputArray.Length; index++)
            {
                for (int i = 0; i < inputArray.Length; i++)
                {

                    if (inputArray[index].Length == inputArray[i].Length && index != i && indexReplacement[index] != true && indexReplacement[i] != true)
                    {
                        int[] workArray = (int[])inputArray[index].Clone();

                        inputArray[index] = inputArray[i];
                        inputArray[i] = workArray;

                        answer = true;
                        indexReplacement[index] = true;
                        indexReplacement[i] = true;
                    }
                }

            }
            // тестовая печать:
            //Console.WriteLine("Новый массив");
            //for (int i = 0; i < inputArray.Length; i++)
            //{
            //    Console.Write("testArray[{0}]= ", i);
            //    for (int j = 0; j < inputArray[i].Length; j++)
            //    {
            //        Console.Write("{0,3}", inputArray[i][j]);
            //    }
            //    Console.WriteLine("");
            //}
            //Console.WriteLine("answer={0}", answer);

            return answer;
        } 
        //end 1

        public int[][] LifeCalculations(int[][] inputArray)
        { 
            //throw new NotImplementedException();
            // 2 <summary>
            /// Daniel rectangular array of integers of 5 to 10.
            /// Already filled with values ​​0 and 1.
            /// Then treat the array as follows:
            /// Each element if the element 1 
            /// And the sum of all the surrounding elements is greater than 3 or less than 2,
            /// Something new element value 0. If the element 0 
            /// And the sum of all its neighbors is equal to 3, the new value of the element 1.
            /// </summary>
            /// < param  name = " inputArray " > original array. Should remain unaltered </ param >
            /// < returns > returns a new array with the new values ​​</ returns >
            //int sizeLineArray = inputArray.Length;

            // Создание и инициализация массива с нулевыми первыми и последними строками и солбцами
            int[][] workArray = new int[inputArray.Length + 2][];
            int secondIndex = inputArray[1].Length;

            for (int i = 0; i < inputArray.Length + 2; i++)
            {
                workArray[i] = new int[secondIndex + 2];
            }
            // Создание и инициализация массива весов каждого элемента входящего массива
            int[][] weightCellsInputArray = new int[inputArray.Length][];
            for (int i = 0; i < inputArray.Length; i++)
            {
                weightCellsInputArray[i] = new int[secondIndex];
            }
            // Создание массива для ответов 
            int[][] answerArray = (int[][])inputArray.Clone();

            // Посчет весов ячеек входного массива (вес ячейки = сумма значений в окружающих ячейках)
            // Заливка значений входного массива в массив, в котором значения 1-й, последней строки и столбы = 0
            for (int i = 0; i < inputArray.Length; i++)
            {
                for (int j = 0; j < inputArray[i].Length; j++)
                {
                    workArray[i + 1][j + 1] = inputArray[i][j];
                }
            }
            // Посчет весов ячеек входного массива (вес ячейки = сумма значений в окружающих ячейках)
            int k = 1;
            for (int i = 0; i < inputArray.Length; i++)
            {
                int l = 1;
                int a = 1;
                for (int j = 0; j < inputArray[i].Length; j++)
                {
                    weightCellsInputArray[i][j] = workArray[k - 1][l - 1] + workArray[k - 1][l] + workArray[k - 1][l + 1] +
                                                  workArray[k][l - 1] + 0 + workArray[k][l + 1] +
                                                  workArray[k + 1][l - 1] + workArray[k + 1][l] + workArray[k + 1][l + 1];
                    l++;
                }
                k++;
            }


            Console.WriteLine("контроль веса ячеек");
            for (int i = 0; i < inputArray.Length; i++)
            {
                for (int j = 0; j < inputArray[i].Length; j++)
                {
                    Console.Write(weightCellsInputArray[i][j]);
                }
                Console.WriteLine("");
            }

            // Ограничения для подсчета веса ячейки входного массива
            int minWeigtFor1 = 2;
            int maxWeigtFor1 = 3;
            int valueWeigtFor0 = 3;
            // формирование выходного массива
            for (int i = 0; i < inputArray.Length; i++)
            {
                for (int j = 0; j < inputArray[i].Length; j++)
                {
                    if (answerArray[i][j] == 1 && (weightCellsInputArray[i][j] < minWeigtFor1 || weightCellsInputArray[i][j] > maxWeigtFor1))
                    {
                        answerArray[i][j] = 0;
                    }
                    else
                    {
                        if (answerArray[i][j] == 0 && weightCellsInputArray[i][j] == valueWeigtFor0)
                        {
                            answerArray[i][j] = 1;
                        }

                    }
                }

            }

            return answerArray;
        }//end2



        public int CalculateEqualPairs(int[] inputArray)
        {
            //throw new NotImplementedException();
            // 3
            /// <summary>
            /// Find how much the incoming array of identical pairs of adjacent elements.
            /// Example array 0, 0, 1, 2, 2, 3 - two identical pairs of adjacent units
            /// </summary>
            /// < param  name = " inputArray " > input array. should remain unaltered. </ param >
            /// < returns > the number of pairs of identical adjacent elements </ returns >
            //      int CalculateEqualPairs(int[] inputArray);
            //
            int answer = 0;
            for (int i = 0; i < inputArray.Length - 1; i++)
            {
                if (inputArray[i] == inputArray[i + 1])
                {
                    answer++;
                }
            }
            return answer;
        }
        //end 3 
    }
}
