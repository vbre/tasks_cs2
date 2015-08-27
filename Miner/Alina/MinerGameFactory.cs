using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miner.Alina
{
    class MinerGameFactory : IMinerGameFactory
    {
        public IMinerGame NewEmptyGame(string playerName, Tuple<int, int> rowsCols)
        {
            return new MinerGame(playerName, rowsCols.Item1, rowsCols.Item2);
        }

        public IMinerGame NewRandomGame(string playerName, Tuple<int, int> rowsCols, int bombs)
        {
            return new MinerGame(playerName, rowsCols.Item1, rowsCols.Item2, bombs);
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
