using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miner.Elena
{
    class MinerGame : IMinerGame
    {
        public bool SetBomb(int row, int col)
        {
            throw new NotImplementedException();
        }

        public bool IsGameStarted
        {
            get { throw new NotImplementedException(); }
        }

        public void Start()
        {
            throw new NotImplementedException();
        }

        public bool Win
        {
            get { throw new NotImplementedException(); }
        }

        public bool Lose
        {
            get { throw new NotImplementedException(); }
        }

        public int OpenCell(int row, int col)
        {
            throw new NotImplementedException();
        }

        public CellStatus this[int row, int col]
        {
            get { throw new NotImplementedException(); }
        }
    }
}
