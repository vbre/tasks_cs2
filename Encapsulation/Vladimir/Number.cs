using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation.Vladimir
{
    class Number
    {
        public static void Test()
        {
            Money m = new Money(1018);
            Money m1 = new Money(25, 51);
            Money m2 = new Money(1, 58);

            Money m3 = m1 + m2;
            Money m4 = m1 - m2;

            Money m5 = m1 *2;
            Money m6 = 2 * m1;
            Money m7 = m1/2;
            
            Money m8 = new Money((float)25.51);

            bool m9 = m3 > m2;
            bool m10 = m1 < m2;

            int hrivnas = m1.Hrivnas;
            int kopecks = m1.Kopecks;

            int totalKopecks = (int)m1;
            float someMoney = (float)m1;
            string amount = (string)m1;

            Console.WriteLine("m=  {0}", m);
            Console.WriteLine("m1= {0}", m1);
            Console.WriteLine("m2= {0}", m2);
            Console.WriteLine("m3= {0}", m3);
            Console.WriteLine("m4= {0}", m4);
            Console.WriteLine("m5= {0}", m5);
            Console.WriteLine("m6= {0}", m6);
            Console.WriteLine("m7= {0}", m7);
            Console.WriteLine("m8= {0}", m8);
            Console.WriteLine("m9= {0}", m9);
            Console.WriteLine("m10={0}", m10);
            Console.WriteLine("totalKopecks= {0}", totalKopecks);
            Console.WriteLine("someMoney= {0}", someMoney);
            Console.WriteLine("amount= {0}", amount);

            Console.ReadKey();
            //-------------------------------------

            Complex c1 = new Complex(1, 1);
            Complex c2 = new Complex(1, 1);
            Complex totalC = c1 + c2;
            Complex differenceС = c1 - c2;
            Complex multiC = c1 * c2;
            Complex divC = c1 / c2;

            Console.WriteLine();
            Console.WriteLine("c1= {0}", c1);
            Console.WriteLine("totalC= {0}", totalC);
            Console.WriteLine("differenceС= {0}", differenceС);
            Console.WriteLine("multiC= {0}", multiC);
            Console.WriteLine("divC= {0}", divC);

            Console.WriteLine("c1= {0}", c1);
            c1.ViewTrigonom = true;
            Console.WriteLine("c1= {0}", c1);

            Console.ReadKey();
            //-----------------------------

            PriorityQueue<int> testQueue = new PriorityQueue<int>();
            testQueue.Enqueue(1, 0);
            testQueue.Enqueue(2, 0);
            testQueue.Enqueue(3, 0);
            testQueue.Enqueue(4, 0);
            testQueue.Enqueue(5, 0);

            testQueue.Enqueue(1, 2);
            testQueue.Enqueue(2, 2);
            testQueue.Enqueue(3, 3);
            testQueue.Enqueue(4, 3);
            testQueue.Enqueue(5, 5);

            Console.WriteLine();
            Console.WriteLine("First test {0}", testQueue.First());  // 1
            Console.WriteLine("Last test {0}", testQueue.Last());    // 5
            
            Console.WriteLine("First test {0} с приоритетом {1}", testQueue.First(2), 2);  //1
            Console.WriteLine("Last test {0} с приоритетом {1}", testQueue.Last(3), 3);    // 4

            int p1 = 0;
            Console.WriteLine("число элементов с приоритетом {0} = {1}", p1, testQueue.GetCount(p1));  //5
            p1 = 2;
            Console.WriteLine("число элементов с приоритетом {0} = {1}", p1, testQueue.GetCount(p1));  //2
            p1 = 5;
            Console.WriteLine("число элементов с приоритетом {0} = {1}", p1, testQueue.GetCount(p1));  //1

            Console.ReadKey();
            //-----------------------------


            // 080915...KlassWork

            MyDictionary dict = new MyDictionary();
    
            for (int i = 0; i <10; i++)
            {
             dict.Add(new Student()
                  {FirstName = "1"+i;
                   LastName = "2"+i;
                   applicationDate = new DtaTime(2015,11,11);
                   birthDay = new DtaTime(2015,12,12);
                   rating =0; personalCode =1+i} )                   
            }


    class MyDictionary : KeyedCollection<Tuple<string, string, DateTime, int>, Student>
    { 
       protected override Tuple<Tuple<string, string, DateTime, int>> GetForItem(Student S)
       {
           throw new NotImplementedException();
       }
   }
    

   class MyCollection<T> : Collection<Student> 
   {
       protected override void ClearItems()
       {
            base.ClearItems();
            Console.WriteLine("Cleared!");
       }

       protected override void InsertItem(int index,T item)
       {
            base.InsertItem(indeх,item);
            Console.WriteLine("Inserted!");
       }

       protected override void RemoveItem(int index)
       {
           base.RemoveItem(index);
           Console.WriteLine("Removed!");
       }

       protected override void SetItem(int index, T item)
       {
           base.SetItem(index,item);
           Console.WriteLine("Seted!");
       }
       //================================================
 
   }









      }
    }
}




