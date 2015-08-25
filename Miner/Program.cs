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
                Console.WriteLine("Testing factory {0}...", factory.ToString());
                try
                {
                    /* empty game */
                    {
                        Console.WriteLine("Testing empty game...");
                        IMinerGame game = factory.NewEmptyGame("Dummy", new Tuple<int, int>(5, 5));
                        Assert(!game.IsGameStarted, "Game shouldn't be started yet");
                    }

                    /* random game */
                    {
                        Console.WriteLine("Testing random game...");
                        IMinerGame game = factory.NewEmptyGame("Dummy", new Tuple<int, int>(5, 5));
                        Assert(!game.IsGameStarted, "Game shouldn't be started yet");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Something was wrong with {0}", factory.ToString());
                }
                Console.WriteLine("Factory {0} done.", factory.ToString());
            }
            
        }

        static void Assert(bool condition, string message)
        {
            if (!condition)
            {
                Console.WriteLine("ASSERTION FAILED: {0}", message);
            }
        }
    }
}
