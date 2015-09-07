using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation.Valeriya
{
    class EncapsulationExercises : IEncapsulationExercises
    {
        static Random rnd = new Random();

        public static void PrintQueue(PriorityQueue<int> queue)
        {
            for (int i = 0; i < queue.Count; i++)
            {
                Console.WriteLine(queue[i]);
            }
        }

        public void WorkPriorityQueue()
        {
            PriorityQueue<int> intPriorityQueue = new PriorityQueue<int>();
            int priorityTest;
            int valueTest;
            int inputIndexForTestLat;
            int inputIndexForTestFirst;
            int inputIndexForTestGetCount;
            intPriorityQueue.Add(0, rnd.Next(1, 100));
            intPriorityQueue.Add(1, rnd.Next(1, 100));
            intPriorityQueue.Add(1, rnd.Next(1, 100));
            intPriorityQueue.Add(3, rnd.Next(1, 100));
            intPriorityQueue.Add(5, rnd.Next(1, 100));
            intPriorityQueue.Add(5, rnd.Next(1, 100));
            intPriorityQueue.Add(6, rnd.Next(1, 100));
            intPriorityQueue.Add(7, rnd.Next(1, 100));
            intPriorityQueue.Add(8, rnd.Next(1, 100));
            intPriorityQueue.Add(8, rnd.Next(1, 100));
            intPriorityQueue.Add(8, rnd.Next(1, 100));
            PrintQueue(intPriorityQueue);

            try
            {
                Console.WriteLine("Count of elems = {0}", intPriorityQueue.Count);

                Console.WriteLine("Enter priority to find last elem");
                Int32.TryParse(Console.ReadLine(), out inputIndexForTestLat);
                Console.WriteLine("The last elem is {0}", intPriorityQueue.Last(inputIndexForTestLat));

                Console.WriteLine("Enter priority to find first elem");
                Int32.TryParse(Console.ReadLine(), out inputIndexForTestFirst);
                Console.WriteLine("The first elem is {0}", intPriorityQueue.First(inputIndexForTestFirst));

                Console.WriteLine("Enter priority to find count elems");
                Int32.TryParse(Console.ReadLine(), out inputIndexForTestGetCount);
                Console.WriteLine("Count of elems with priority {0} is {1}", inputIndexForTestGetCount, intPriorityQueue.GetCount(inputIndexForTestFirst));

                Console.WriteLine("The element {0} dequeued", intPriorityQueue.Dequeue());
                PrintQueue(intPriorityQueue);

                Console.WriteLine("Enter the element<priority, value> to push");
                Int32.TryParse(Console.ReadLine(), out priorityTest);
                Int32.TryParse(Console.ReadLine(), out valueTest);
                intPriorityQueue.Enqueue(valueTest, priorityTest);
                PrintQueue(intPriorityQueue);
            }
            catch (EmptyQueueException e)
            {
                Console.WriteLine("Error: The queue is empty", e.Message);
            }

            Console.ReadKey();
        }

        public void MoneyMoney()
        {
            throw new NotImplementedException();
        }
    }
}
