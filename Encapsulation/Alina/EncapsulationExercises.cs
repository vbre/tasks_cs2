using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation.Alina
{
    class EncapsulationExercises : IEncapsulationExercises
    {
        public void MoneyMoney()
        {
            throw new NotImplementedException();
        }


        public void WorkPriorityQueue()
        {
            Student firstStudent = new Student("Alina", "Kylish", 123456789, new DateTime(1988, 4, 3));
            Student secondStudent = new Student("Elena", "Kylish", 987654321, new DateTime(1987, 8, 15));
            Student thirdStudent = new Student("Oleg", "Ivanov", 975312468, new DateTime(1992, 11, 20));
            Student fourthStudent = new Student("Andrey", "Pavlov", 1243576890, new DateTime(1977, 8, 10));
            PriorityQueue<Student> students = new PriorityQueue<Student>();
            students.Enqueue(firstStudent, 0);
            students.Enqueue(secondStudent, 1);
            students.Enqueue(thirdStudent, 2);
            students.Enqueue(fourthStudent, 0);
            Console.WriteLine(students.Count());
            Console.WriteLine(students.First());
            Console.WriteLine(students.Last());  
            students.Dequeue();
            Console.WriteLine(students.Count());
            Console.ReadKey();
            students.Clear();
            students.Dequeue(); // throw exeption with message "Queue is empty. There is no value in queue"
        }

        public void WorkCollectionInheritedClasses()
        {
            Student firstStudent = new Student("Alina", "Kylish", 123456789, new DateTime(1988, 4, 3));
            Student secondStudent = new Student("Elena", "Kylish", 987654321, new DateTime(1987, 8, 15));
            Student thirdStudent = new Student("Oleg", "Ivanov", 975312468, new DateTime(1992, 11, 20));
            MyDictionary students = new MyDictionary();
            Tuple<string, string, int> key = new Tuple<string,string,int>("Alina", "Kylish", 123456789);
            students.Add(firstStudent);
            if (!students.Contains(key))
            {
                Console.WriteLine("This key is not found");
            }
            else
            {
                Console.WriteLine("This key is found");      
            }

            MyCollection students1 = new MyCollection();
            students1.Add(firstStudent);
            students1.Add(secondStudent);
            students1.Insert(0, thirdStudent);
            students1.Add(firstStudent);
            students1.Remove(firstStudent);
            students1.Clear();
            Console.ReadKey();

        }
    }
}
