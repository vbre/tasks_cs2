using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miner.Valeriya
{
    class GameCell
    {
        private bool isEmpty;
        private bool isOpened;
        private int countOfBombsAround;
        public bool IsOpened { get; set; }
        public bool IsEmpty { get; set; }
        public int CountOfBombsAround{ get; set; }

        public GameCell(bool isEmpty, bool isOpened)
        {
            this.isEmpty = isEmpty;
            this.isOpened = isOpened;
            countOfBombsAround = 0;
        }


    }
}
