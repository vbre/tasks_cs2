using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miner.Valeriya
{
    class GameCell
    {
        bool isEmpty;
        bool isOpened;

        public GameCell(bool isEmpty, bool isOpened)
        {
            this.isEmpty = isEmpty;
            this.isOpened = isOpened;
        }
    }
}
