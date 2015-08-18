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
        // 1
            
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
            return answer;
        }
        //end 1

        public void MyConntrolWriteWork1(int[][] inputArray)
        {
         //   тестовая печать:
            Console.WriteLine("Новый массив");
            for (int i = 0; i < inputArray.Length; i++)
            {
                Console.Write("testArray[{0}]= ", i);
                for (int j = 0; j < inputArray[i].Length; j++)
                {
                    Console.Write("{0,3}", inputArray[i][j]);
                }
                Console.WriteLine("");
            }
        }
//---------------------------------------------------------
        public int[][] LifeCalculations(int[][] inputArray)
        {
            // 2 <summary>
        
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
                for (int j = 0; j < inputArray[i].Length; j++)
                {
                    weightCellsInputArray[i][j] = workArray[k - 1][l - 1] + workArray[k - 1][l] + workArray[k - 1][l + 1] +
                                                  workArray[k][l - 1] + workArray[k][l + 1] +
                                                  workArray[k + 1][l - 1] + workArray[k + 1][l] + workArray[k + 1][l + 1];
                    l++;
                }
                k++;
            }

            bool f = false;  // Контрольная печать веса ячеек
            if (f)
            {
                MyControlWriteWork2WeightCells(weightCellsInputArray);
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

        public static void MyControlWriteWork2WeightCells(int[][] weightCellsInputArray)
        {// контрольная печать веса ячеек

            Console.WriteLine("контроль веса ячеек");
            for (int i = 0; i < weightCellsInputArray.Length; i++)
            {
                for (int j = 0; j < weightCellsInputArray[i].Length; j++)
                {
                    Console.Write(weightCellsInputArray[i][j]);
                }
                Console.WriteLine("");
            }
        }
//------------------------

        public int CalculateEqualPairs(int[] inputArray)
        {
        // 3
            int answer = 0;
            for (int i = 0; i < inputArray.Length - 1; i++)
            {
                if (inputArray[i] == inputArray[i + 1])
                {
                    answer++;
                }
            }
            return answer;
        }//end 3 
    }
}
