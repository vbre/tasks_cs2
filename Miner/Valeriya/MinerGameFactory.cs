using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miner.Valeriya
{
    class MinerGameFactory : IMinerGameFactory
    {
        public IMinerGame NewEmptyGame(string playerName, Tuple<int, int> rowsCols)
        {
           MinerGame NewEmptyGame = new MinerGame(rowsCols.Item1, rowsCols.Item2);
           return NewEmptyGame;
        }

        public IMinerGame NewRandomGame(string playerName, Tuple<int, int> rowsCols, int bombs)
        {
            MinerGame NewRandomGame = new MinerGame(rowsCols.Item1, rowsCols.Item2, bombs);
            return NewRandomGame;
        }

        internal void Test()
        {
            int Width = 0;
            int Height = 0;
            int bombs = 0;
            Console.WriteLine("Hello, I'm a Miner game, please, choose type of game:\nFor Empty game type 0\nFor Random game type 1");
            string typeOfGame = Console.ReadLine();
            Console.WriteLine("Please, enter your name");
            string playerName = Console.ReadLine();
            Console.WriteLine("Please, enter field Width = ");
            Int32.TryParse(Console.ReadLine(), out Width);
            Console.WriteLine("Please, enter field Height = ");
            Int32.TryParse(Console.ReadLine(), out Height);
            
            switch (typeOfGame)
            {
                case "0":
                    IMinerGame emptyGame = NewEmptyGame(playerName, new Tuple<int, int>(Height, Width));
                    break;
                case "1":
                    Console.WriteLine("Please, specify number of bombs on the field");
                    Int32.TryParse(Console.ReadLine(), out bombs);
                    IMinerGame randomGame = NewRandomGame(playerName, new Tuple<int, int>(Height, Width), bombs);
                    break;
            }
        }


        void IMinerGameFactory.Test()
        {
            throw new NotImplementedException();
        }
    }
}
