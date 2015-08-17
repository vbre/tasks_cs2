using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays2
{
    class Program
    {
        static void Assert(bool condition, string message)
        {
            if (!condition)
            {
                Console.WriteLine("Error: " + message);
            }
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

                    // Equal pairs checking
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
