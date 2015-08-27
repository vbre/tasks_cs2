using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miner.Alina
{
    class MinerGame : IMinerGame
    {
        string playerName;
        int heigh;
        int width;
        int bombs;
        enum Statuses { 
            Empty = 1,
            HasMine,
            OneAround, TwoAround, ThreeAround, FourAround, FiveAround, SixAround, SevenAround, EightAround,       
        };
        public class oneCell
        {
            public bool StartStatus {get; set;}
            public Statuses StatusInGame { get; set; }
            public oneCell(Statuses statusInGame)
            {
                StartStatus = false;
                this.StatusInGame = statusInGame;
            }
        }
        oneCell [,] gameField;
        public MinerGame(string playerName, int heigh, int width)
        {
            this.playerName = playerName;
            this.heigh = heigh;
            this.width = width;
            gameField = new oneCell[heigh, width];
        }
        public MinerGame(string playerName, int heigh, int width, int bombs)
            :this(playerName, heigh, width)
        {
            this.bombs = bombs;
        }

        public int Width
        {
            get { return width; }
        }

        public int Height
        {
            get { return heigh; }
        }
        public bool SetBomb(int row, int col)
        {
            gameField[row, col].StatusInGame = Statuses.HasMine;
            return true;
            //TODO: check field size
        }

        public bool IsGameStarted
        {
            get { throw new NotImplementedException(); }
        }

        public void Start()
        {
            
            int amountBombsNear;
            Random rnd = new Random();


        }

        public bool Win
        {
            get { throw new NotImplementedException(); }
        }

        public bool Lose
        {
            get { throw new NotImplementedException(); }
        }
        int BombCalculation(int row, int col)
        {
            int sum = 0;
            if (gameField[row - 1, col - 1].StatusInGame == Statuses.HasMine && row != 0 && col != 0)
            {
                sum += 1;
            }
            if (gameField[row - 1, col].StatusInGame == Statuses.HasMine && row != 0)
            {
                sum += 1;
            }
            if (gameField[row - 1, col + 1].StatusInGame == Statuses.HasMine && row != 0 && col != width)
            {
                sum += 1;
            }
            if (gameField[row, col - 1].StatusInGame == Statuses.HasMine && col != 0)
            {
                sum += 1;
            }
            if (gameField[row, col + 1].StatusInGame == Statuses.HasMine && col != width)
            {
                sum += 1;
            }
            if (gameField[row + 1, col - 1].StatusInGame == Statuses.HasMine && col != 0 && row != heigh )
            {
                sum += 1;
            }
            if (gameField[row + 1, col].StatusInGame == Statuses.HasMine && row != heigh)
            {
                sum += 1;
            }
            if (gameField[row + 1, col + 1].StatusInGame == Statuses.HasMine && col != width && row != heigh)
            {
                sum += 1;
            }
            return sum;
        }
        public bool OpenCell(int row, int col)
        {
            bool inField = InField(row, col);
            if (inField)
            {
                gameField[row, col].StartStatus = true;
                switch (BombCalculation(row,col))
                {
                    case 0: gameField[row, col].StatusInGame = Statuses.Empty;
                        break;
                    case 1: gameField[row, col].StatusInGame = Statuses.OneAround;
                        break;
                    case 2: gameField[row, col].StatusInGame = Statuses.TwoAround;
                        break;
                    case 3: gameField[row, col].StatusInGame = Statuses.ThreeAround;
                        break;
                    case 4: gameField[row, col].StatusInGame = Statuses.FourAround;
                        break;
                    case 5: gameField[row, col].StatusInGame = Statuses.FiveAround;
                        break;
                    case 6: gameField[row, col].StatusInGame = Statuses.SixAround;
                        break;
                    case 7: gameField[row, col].StatusInGame = Statuses.SevenAround;
                        break;
                    case 8: gameField[row, col].StatusInGame = Statuses.EightAround;
                        break;
                }
            }
            return inField;
        }

        public CellStatus this[int row, int col]
        {
            get {
                if (col > 0 && row > 0 && row <= heigh - 1 && col <= width - 1)
                {
                     
                }
                else
                {
                    //return new IndexOutOfRange exception
                }
                
            }
        }
        bool InField (int row, int col)
        {
            return (col > 0 && row > 0 && row <= heigh - 1 && col <= width - 1);
        }

    }
}
