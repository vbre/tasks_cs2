using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays2
{
    class Program
    {
        static bool Assert(bool condition, string message)
        {
            if (!condition)
            {
                Console.WriteLine("ERROR: " + message);
            }
            else
            {
                Console.WriteLine("Passed.");
            }
            return condition;
        }

        static void Main(string[] args)
        {
            List<IArraysJob> arraysJobs = new List<IArraysJob>();
            arraysJobs.Add(new Alina.ArraysJob());
            arraysJobs.Add(new Andrey.ArraysJob());
            arraysJobs.Add(new Elena.ArraysJob());
            arraysJobs.Add(new Konstantin.ArraysJob());
            arraysJobs.Add(new Valeriya.ArraysJob());
            arraysJobs.Add(new Vladimir.ArraysJob());

            foreach (var arraysJob in arraysJobs)
            {
                try
                {
                    // Jagged exchange checking
                    int[][] arr1 = { new int[]{1, 2, 3}, new int[]{4, 5}, new int[]{6, 7, 8, 9 } };
                    Assert(!arraysJob.JaggedArrayExchange(arr1), "Найдены строки одинаковой длины в массиве без строк одинаковой длины!");

                    int[][] arr2 = { new int[] { 1, 2, 3 }, new int[] { 4, 5 }, new int[] { 6, 7, 8 }, new int[]{9, 10, 11} };
                    Assert(arraysJob.JaggedArrayExchange(arr2), "Не найдены строки одинаковой длины в массиве!");
                    Assert(arr2[0][2] == 8, "Неверный обмен");
                    Assert(arr2[2][1] == 2, "Неверный обмен");
                    Assert(arr2[3][0] == 9, "Неверный обмен");

                    // Life checking
                    /// 	для каждого элемента если в элементе 1 
                    /// 	и сумма всех окружающих его элементов больше 3 или меньше 2,
                    /// 	то новое значение элемента 0. Если в элементе 0 
                    /// 	и сумма всех окружающих его элементов равна 3, то новое значение элемента 1.
                    int[][] lifeArray = { 
                        new int[] { 0, 1, 0, 0 },
                        new int[] { 0, 1, 1, 0 },
                        new int[] { 0, 1, 0, 1 },
                        new int[] { 0, 1, 1, 0 },
                        new int[] { 0, 1, 1, 0 },
                        new int[] { 0, 1, 0, 1 }
                    };
                    int[][] lifeArray2nd = { 
                        new int[] { 0, 1, 1, 0 },
                        new int[] { 1, 1, 0, 0 },
                        new int[] { 1, 0, 0, 1 },
                        new int[] { 1, 0, 0, 1 },
                        new int[] { 1, 0, 0, 1 },
                        new int[] { 0, 1, 0, 0 }
                    };
                    int[][] lifeArrayToCheck = arraysJob.LifeCalculations(lifeArray);
                    if(!Assert(lifeArrayToCheck != null, "Неверный результат: null"))
                    {
                        continue;
                    }
                    Assert(lifeArrayToCheck != lifeArray, "Неверный результат: вернули входной массив");
                    Assert(lifeArrayToCheck.Length == lifeArrayToCheck.Length, "Неверное количество строк в массиве с результатом");
                    for (int row = 0; row < lifeArray2nd.Length; row++)
                    {
                        if (lifeArrayToCheck[row] == null)
                        {
                            Assert(false, "Отсутствует строка " + row);
                            continue;
                        }
                        if(!Assert(lifeArrayToCheck[row].Length == lifeArray2nd[row].Length, "неверная длина строки " + row + "в массиве с результатом"))
                        {
                            continue;
                        }
                        for (int col = 0; col < lifeArray2nd[row].Length; col++)
                        {
                            Assert(lifeArray2nd[row][col] == lifeArrayToCheck[row][col], "неверное значение " + lifeArrayToCheck[row][col] + " в строке " + row + " столбце " + col);
                        }
                    }

                    // Equal pairs checking
                    int[] arrPairs = { 1, 1, 0, 3, 3, 3, 5, 3, 3, 9, 6, 6, 6 };
                    Assert(arraysJob.CalculateEqualPairs(arrPairs) == 6, "Неверно посчитано количество пар в массиве");
                    int[] arrPairs2 = { 1, 0, 3, 5, 3, 9, 1, 0, 6 };
                    Assert(arraysJob.CalculateEqualPairs(arrPairs2) == 0, "Неверно посчитано количество пар в массиве без пар");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Где-то ошибка {0}: {1}", arraysJob.ToString(), e.Message);
                }
            }
            Console.ReadKey(true);
        }
    }
}
