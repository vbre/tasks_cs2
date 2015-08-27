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
            throw new NotImplementedException();
        }


        void IMinerGameFactory.Test()
        {
            throw new NotImplementedException();
        }
    }
}
