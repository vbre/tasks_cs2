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
            bool inField = InField(row, col);
            if (inField)
            {
                gameField[row, col].StatusInGame = Statuses.HasMine;
                inField = true;
            }
            return inField;
 
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
                if (gameField[row, col].StatusInGame == Statuses.HasMine)
                {
                    gameField[row, col].StatusInGame = Statuses.HasMine;
                }
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
                bool inField = InField(row, col);
                if (inField)
                {
                    switch (gameField[row, col].StatusInGame)
                    {
                        case Statuses.Empty: gameField[row, col].StatusInGame = Statuses.Empty;
                            break;
                        case Statuses.HasMine: gameField[row, col].StatusInGame = Statuses.HasMine;
                            break;
                        case Statuses.OneAround: gameField[row, col].StatusInGame = Statuses.OneAround;
                            break;
                        case Statuses.TwoAround: gameField[row, col].StatusInGame = Statuses.TwoAround;
                            break;
                        case Statuses.ThreeAround: gameField[row, col].StatusInGame = Statuses.ThreeAround;
                            break;
                        case Statuses.FourAround: gameField[row, col].StatusInGame = Statuses.FourAround;
                            break;
                        case Statuses.FiveAround: gameField[row, col].StatusInGame = Statuses.FiveAround;
                            break;
                        case Statuses.SixAround: gameField[row, col].StatusInGame = Statuses.SixAround;
                            break;
                        case Statuses.SevenAround: gameField[row, col].StatusInGame = Statuses.SevenAround;
                            break;
                        case Statuses.EightAround: gameField[row, col].StatusInGame = Statuses.EightAround;
                            break;
                        default:
                            
                            break;
                    }
                    return (CellStatus)gameField[row, col].StatusInGame;
                }
                else
                {
                   return new IndexOutOfRangeException();
                }
                }               
            }
        bool InField (int row, int col)
        {
            return (col > 0 && row > 0 && row <= heigh - 1 && col <= width - 1);
        }       
    }
}
