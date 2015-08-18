using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
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

        private class Potatoe : IPotatoe
        {
            public Potatoe(bool isBad) { IsBad = isBad; }

            public bool IsBad { get; private set; }
        }

        static void Main(string[] args)
        {
            List<ICollections> localCollections = new List<ICollections>();
            localCollections.Add(new Alina.Collections());
            localCollections.Add(new Andrey.Collections());
            localCollections.Add(new Elena.Collections());
            localCollections.Add(new Konstantin.Collections());
            localCollections.Add(new Valeriya.Collections());
            localCollections.Add(new Vladimir.Collections());

            foreach (var collection in localCollections)
            {
                try
                {
                    List<IPotatoe> myPotatoes = new List<IPotatoe>();
                    myPotatoes.Add(new Potatoe(false));
                    myPotatoes.Add(new Potatoe(true));
                    myPotatoes.Add(new Potatoe(true));
                    myPotatoes.Add(new Potatoe(false));
                    myPotatoes.Add(new Potatoe(false));
                    myPotatoes.Add(new Potatoe(true));
                    myPotatoes.Add(new Potatoe(false));
                    myPotatoes.Add(new Potatoe(true));
                    myPotatoes.Add(new Potatoe(true));

                    List<IPotatoe> goodPotatoes;
                    List<IPotatoe> badPotatoes;

                    Console.WriteLine("Working at: " + collection.ToString());
                    int good = collection.SortPotatoes(myPotatoes, out goodPotatoes, out badPotatoes);
                    Assert(good == 4, "Возвращено неверное количество хорошей картошки");
                    if (!Assert(goodPotatoes != null, "мешок с хорошей картошкой не существует!"))
                    {
                        continue;
                    }
                    if (!Assert(badPotatoes != null, "мешок с плохой картошкой не существует!"))
                    {
                        continue;
                    }
                    Assert(goodPotatoes.Count == 4, "в мешке с хорошей картошкой неверное количество");
                    Assert(badPotatoes.Count == 5, "в мешке с плохой картошкой неверное количество");

                    Assert(goodPotatoes.TrueForAll((p)=>{return !p.IsBad;}), "в мешок с хорошей картошкой попала плохая");
                    Assert(badPotatoes.TrueForAll((p) => { return p.IsBad; }), "в мешок с плохой картошкой попала хорошая");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Где-то ошибка {0}: {1}", collection.ToString(), e.Message);
                }

            }
            Console.ReadKey(true);
        }
    }
}
