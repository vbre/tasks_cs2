using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IMinerGameFactory> factories = new List<IMinerGameFactory>();
            factories.Add(new Alina.MinerGameFactory());
            factories.Add(new Andrey.MinerGameFactory());
            factories.Add(new Elena.MinerGameFactory());
            factories.Add(new Konstantin.MinerGameFactory());
            factories.Add(new Valeriya.MinerGameFactory());
            factories.Add(new Vladimir.MinerGameFactory());

            foreach (var factory in factories)
            {
                try
                {

                }
                catch (Exception e)
                { 
                    Console.WriteLine("Something ")
                }
            }
            
        }


    }
}
