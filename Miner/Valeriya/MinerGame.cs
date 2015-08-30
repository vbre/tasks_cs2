using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miner.Valeriya
{
    
    class MinerGame : IMinerGame
    {
        bool isGameEmpty;
        bool isGameStarted = false;
        bool isGameOver = false;
        static Random rand = new Random();
        GameCell[][] gameField = null;
        public MinerGame (int rowNumber, int collNumber)
        {
            isGameStarted = true;
            isGameEmpty = true;
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
            isGameStarted = true;
            isGameEmpty = false;
            gameField = new GameCell[rowNumber][];
            while (countOfBombs != 0)
            {
                int i = rand.Next(0, rowNumber);
                int j = rand.Next(0, collNumber);
                SetBomb (i, j);
            }
        }

        public bool SetBomb(int row, int col)
        {
            bool bombIsSet = false;
            if (row >= 0 && row < Height && col >= 0 && col < Width && isGameEmpty == true && gameField[row][col].IsEmpty == true)
            {
                gameField[row][col].IsEmpty = false;
                if (row - 1 >=0 && col - 1 >= 0 && row - 1 < Height && col - 1 < Width)
                {
                    gameField[row][col].CountOfBombsAround++;
                }
                if (row - 1 >= 0 && col >= 0 && row - 1 < Height && col < Width)
                {
                    gameField[row][col].CountOfBombsAround++;
                }
                if (row - 1 >= 0 && col + 1 >= 0 && row - 1 < Height && col + 1 < Width)
                {
                    gameField[row][col].CountOfBombsAround++;
                }
                if (row >= 0 && col - 1 >= 0 && row < Height && col - 1 < Width)
                {
                    gameField[row][col].CountOfBombsAround++;
                }
                if (row >= 0 && col + 1 >= 0 && row < Height && col + 1 < Width)
                {
                    gameField[row][col].CountOfBombsAround++;
                }
                if (row + 1 >= 0 && col - 1 >= 0 && row + 1 < Height && col - 1 < Width)
                {
                    gameField[row][col].CountOfBombsAround++;
                }
                if (row + 1 >= 0 && col >= 0 && row + 1 < Height && col < Width)
                {
                    gameField[row][col].CountOfBombsAround++;
                }
                if (row + 1 >= 0 && col + 1 >= 0 && row + 1 < Height && col + 1 < Width)
                {
                    gameField[row][col].CountOfBombsAround++;
                }
                bombIsSet = true;
            }

            return bombIsSet;
        }

        public bool IsGameStarted
        {
            get { return isGameStarted; }
        }

        public void Start()
        {
                double bombsPercent = 0.2;
                int countOfBombs = (int)(Width * Height * bombsPercent);
                while (countOfBombs != 0)
                {
                    int i = rand.Next(0, Height);
                    int j = rand.Next(0, Width);
                    SetBomb(i, j);
                }
            

            isGameStarted = true;
        }

        public bool Win
        {
            get { throw new NotImplementedException(); }
        }

        public bool Lose
        {
            get { return isGameOver; }
        }

        public bool OpenCell(int row, int col)
        {
            if (row >= 0 && row < Height && col >= 0 && col < Width && gameField[row][col].IsOpened == false)
            {
                if (gameField[row][col].IsEmpty == false)
                {
                    isGameOver = true;
                }
                gameField[row][col].IsOpened = true;
            }

            return gameField[row][col].IsOpened;
        }

        public CellStatus this[int row, int col]
        {
            get {
                CellStatus statusOfCell = 0;
                if (gameField[row][col].IsEmpty == true)
                {
                    statusOfCell = CellStatus.Empty;
                }
                else if (gameField[row][col].IsEmpty == false)
                {
                    statusOfCell = CellStatus.HasMine;
                }
                else if (gameField[row][col].IsOpened == false)
                {
                    statusOfCell = CellStatus.NotOpened;
                }
                if (gameField[row][col].CountOfBombsAround == 1)
                {
                    statusOfCell = CellStatus.OneAround;
                }
                if (gameField[row][col].CountOfBombsAround == 2)
                {
                    statusOfCell = CellStatus.TwoAround;
                }
                if (gameField[row][col].CountOfBombsAround == 3)
                {
                    statusOfCell = CellStatus.ThreeAround;
                }
                if (gameField[row][col].CountOfBombsAround == 4)
                {
                    statusOfCell = CellStatus.FourAround;
                }
                if (gameField[row][col].CountOfBombsAround == 5)
                {
                    statusOfCell = CellStatus.FiveAround;
                }
                if (gameField[row][col].CountOfBombsAround == 6)
                {
                    statusOfCell = CellStatus.SixAround;
                }
                if (gameField[row][col].CountOfBombsAround == 7)
                {
                    statusOfCell = CellStatus.SevenAround;
                }
                if (gameField[row][col].CountOfBombsAround == 8)
                {
                    statusOfCell = CellStatus.EightAround;
                }
                return statusOfCell;
            }
        }


        public int Width
        {
            get { return gameField.Length; }
        }

        public int Height
        {
            get { return gameField[0].Length; }
        }
    }
}
