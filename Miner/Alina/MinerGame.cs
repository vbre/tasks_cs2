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
        public enum Statuses { 
            Undefined,
            Empty = 1,
            HasMine,
            OneAround, TwoAround, ThreeAround, FourAround, FiveAround, SixAround, SevenAround, EightAround,       
        };
        public class oneCell
        {
            public bool StartStatus {get; set;}
            public Statuses StatusInGame { get; set; }
            public oneCell()
            {
                StartStatus = false;
                this.StatusInGame = Statuses.Undefined;
            }
        }
        oneCell [,] gameField;
        public MinerGame(string playerName, int heigh, int width)
            : this(playerName, heigh, width, 0)
        {

        }
        public MinerGame(string playerName, int heigh, int width, int bombs)
        {
            this.playerName = playerName;
            this.heigh = heigh;
            this.width = width;
            gameField = new oneCell[heigh, width];
            for (int row = 0; row < heigh; row++)
            {
                for (int col = 0; col < width; col++)
                {
                    gameField[row, col] = new oneCell();
                }
            }
            Random randomNumber = new Random();
            for (int i = 0; i < bombs; i++)
            {
                SetBomb(randomNumber.Next(0, heigh-1), randomNumber.Next(0, width-1));
            }
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
            if (isGameStarted)
            {
                throw new InvalidOperationException("Нельзя устанавливать бомбы после старта игры");
            }
            bool inField = InField(row, col);
            if (inField)
            {
                gameField[row, col].StatusInGame = Statuses.HasMine;
                inField = true;
                bombs += 1;
            }
            return inField;
 
        }
        bool isGameStarted;
        public bool IsGameStarted
        {
            get { return isGameStarted; }
        }

        public void Start()
        {
            isGameStarted = true;
        }
        bool win;
        public bool Win
        {
            get {
                int counter = 0;
                foreach (var element in gameField)
                {
                    if (element.StartStatus == false)
                    {
                        counter++;
                    }
                }
                return counter == bombs;
            }
        }
        bool lose;
        public bool Lose
        {
            get { return lose; }
        }
        int BombCalculation(int row, int col)
        {
            int sum = 0;
            if (row != 0 && col != 0 && gameField[row - 1, col - 1].StatusInGame == Statuses.HasMine)
            {
                sum += 1;
            }
            if (row != 0 && gameField[row - 1, col].StatusInGame == Statuses.HasMine)
            {
                sum += 1;
            }
            if (row != 0 && col != width && gameField[row - 1, col + 1].StatusInGame == Statuses.HasMine)
            {
                sum += 1;
            }
            if (col != 0 && gameField[row, col - 1].StatusInGame == Statuses.HasMine)
            {
                sum += 1;
            }
            if (col != width && gameField[row, col + 1].StatusInGame == Statuses.HasMine)
            {
                sum += 1;
            }
            if (col != 0 && row != heigh && gameField[row + 1, col - 1].StatusInGame == Statuses.HasMine)
            {
                sum += 1;
            }
            if (row != heigh && gameField[row + 1, col].StatusInGame == Statuses.HasMine)
            {
                sum += 1;
            }
            if (col != width && row != heigh && gameField[row + 1, col + 1].StatusInGame == Statuses.HasMine)
            {
                sum += 1;
            }
            return sum;
        }
        public bool OpenCell(int row, int col)
        {
            if (lose)
            {
                isGameStarted = false;
            }
            if (!isGameStarted)
            {
                throw new InvalidOperationException("Нельзя открывать ячейки до начала игры");
            }
            bool inField = InField(row, col);
            if (inField)
            {
                gameField[row, col].StartStatus = true;
                if (gameField[row, col].StatusInGame == Statuses.HasMine)
                {
                    lose = true;
                }
                else
                {
                    switch (BombCalculation(row, col))
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
            }
            return inField;
        }

        public CellStatus this[int row, int col]
        {
            get {
                bool inField = InField(row, col);
                CellStatus statusReturn = 0;
                if (inField)
                {
                    switch (gameField[row, col].StatusInGame)
                    {
                        case Statuses.Empty: statusReturn = CellStatus.Empty; 
                            break;
                        case Statuses.HasMine: statusReturn = CellStatus.HasMine;
                            break;
                        case Statuses.OneAround: statusReturn = CellStatus.OneAround;
                            break;
                        case Statuses.TwoAround: statusReturn = CellStatus.TwoAround;
                            break;
                        case Statuses.ThreeAround: statusReturn = CellStatus.ThreeAround;
                            break;
                        case Statuses.FourAround: statusReturn = CellStatus.FourAround;
                            break;
                        case Statuses.FiveAround: statusReturn = CellStatus.FiveAround;
                            break;
                        case Statuses.SixAround: statusReturn = CellStatus.SixAround;
                            break;
                        case Statuses.SevenAround: statusReturn = CellStatus.SevenAround;
                            break;
                        case Statuses.EightAround: statusReturn = CellStatus.EightAround;
                            break;
                        case Statuses.Undefined: statusReturn = CellStatus.NotOpened;
                            break;
                    }
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
                return statusReturn;
                }               
            }
        bool InField (int row, int col)
        {
            return (col >= 0 && row >= 0 && row <= heigh - 1 && col <= width - 1);
        }       
    }
}
