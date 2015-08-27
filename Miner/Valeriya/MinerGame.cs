using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miner.Valeriya
{
    
    class MinerGame : IMinerGame
    {
        static Random rand = new Random();
        GameCell[][] gameField = null;
        public MinerGame (int rowNumber, int collNumber)
        {
            gameField = new GameCell[rowNumber][];
            for (int i = 0; i < rowNumber; i++)
            {
                for (int j = 0; j < collNumber; j++)
                {
                    gameField[i][j] = new GameCell(true, false);
                }
            }
        }

        public MinerGame (int rowNumber, int collNumber, int countOfBombs)
        {
            gameField = new GameCell[rowNumber][];
            int isBombPresent = 0;
            for (int i = 0; i < rowNumber; i++)
            {
                for (int j = 0; j < collNumber; j++)
                {
                    if (countOfBombs != 0)
                    {
                        isBombPresent = rand.Next(0, 1);
                        if (isBombPresent == 1)
                        {
                            gameField[i][j] = new GameCell(false, false);
                        }
                        else
                        {
                            gameField[i][j] = new GameCell(true, false);
                        }
                        countOfBombs--;
                    }
                }
            }
        }

        public bool SetBomb(int row, int col)
        {
            bool bombIsSet = false;
            if (row >= 0 && row < gameField.Length && col >= 0 && col < gameField[0].Length)
            {
                gameField[row][col] = new GameCell(false, false);
                bombIsSet = true;
            }

            return bombIsSet;
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

        public bool OpenCell(int row, int col)
        {
            throw new NotImplementedException();
        }

        public CellStatus this[int row, int col]
        {
            get { throw new NotImplementedException(); }
        }


        public int Width
        {
            get { throw new NotImplementedException(); }
        }

        public int Height
        {
            get { throw new NotImplementedException(); }
        }
    }
}
