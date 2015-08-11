using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miner
{
    enum CellStatus { 
        NotOpened = -1,
        Empty = 0, 
        OneAround, TwoAround, ThreeAround, FourAround, FiveAround, SixAround, SevenAround, EightAround,
        HasMine = 100
    }

    interface IMinerGame
    {
        bool SetBomb(int row, int col);

        bool IsGameStarted { get; }

        void Start();

        bool Win { get; }
        bool Lose { get; }

        int OpenCell(int row, int col);

        CellStatus this[int row, int col] { get; }
    }
}
