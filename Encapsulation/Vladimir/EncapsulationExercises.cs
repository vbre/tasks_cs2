using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation.Vladimir
{
    class EncapsulationExercises : IEncapsulationExercises
    {



        public void WorkPriorityQueue()
        {
            throw new NotImplementedException();
        }

        public void MoneyMoney()
        {
            Number.Test();
            

        }


        public void WorkCollectionInheritedClasses()
        {
            throw new NotImplementedException();
        }



    }

    struct Student
    {
      public string FirstName;
             string LastName;
             DateTime applicationDate;
             DateTime birthDay;
             int rating;
             int personalCode;
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

       
   }





}
