using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris_test
{
    internal class Tetris
    {
        public const int Width = 10;
        public const int Height = 24;
        public const int HiddenBoardHeight = 4;

        public int[,] Board;
        public int[,] OldBoard;

        public int CurrentBlock = 0;
        public int CurrentDirection = 0;
        public int CurrentX = 4;
        public int CurrentY = 0;

        private Random random = new Random((int)DateTime.Now.Ticks);

        public Tetris()
        {
            Board = new int[Width, Height];
            OldBoard = new int[Width, Height];

            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    Board[i, j] = 0;
                    OldBoard[i, j] = 1;
                }
            }
        }
    }
}
