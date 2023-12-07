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
        public void NewBlock()
        {
            CurrentX = 4;
            CurrentY = 0;

            SetRandomCurrentBlock();
            MergeCurrentBlockToBoard();


        }

        public void SetRandomCurrentBlock()
        {
            CurrentBlock = (int)random.Next(0, 7);
        }

        public void NextDirection()
        {
            int nextDirection = CurrentDirection;

            switch (CurrentDirection)
            {
                case 0:
                    nextDirection = 1;
                    break;
                case 1:
                    nextDirection = 2;
                    break;
                case 2:
                    nextDirection = 3;
                    break;
                case 3:
                    nextDirection = 0;
                    break;
            }
            RemoveCurrentBlock();

            if (CanAction(nextDirection, CurrentX, CurrentY))
            {
                CurrentDirection = nextDirection;
            }

            MergeCurrentBlockToBoard();
        }

        private bool CanAction(int nextDirection, int currentX, int currentY)
        {
            throw new NotImplementedException();
        }

        private void RemoveCurrentBlock()
        {
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    if (Board[i, j] == 2)
                    {
                        Board[i, j] = 0;
                    }
                }
            }
        }



        private void MergeCurrentBlockToBoard()
        {
            int[,] bloackArray = GetBlockArray(CurrentBlock, CurrentDirection);

            int arrayLength = bloackArray.Length;
            int size = 0;

            switch (arrayLength)
            {
                case 4:
                    size = 2;
                    break;
                case 9:
                    size = 3;
                    break;
                case 16:
                    size = 4;
                    break;

            }

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (bloackArray[i, j] == 1)
                    {
                        Board[CurrentX + i, CurrentY + j] = 2;
                    }
                }
            }
        }
        public void MoveDown()
        {
            RemoveCurrentBlock();

            if (CanAction(CurrentDirection, CurrentX, CurrentY + 1))
            {
                CurrentY++;
                MergeCurrentBlockToBoard();
            }
            else
            {
                MergeCurrentBlockToBoard();
                FixBlock();
                NewBlock();
            }
        }

        private int[,] GetBlockArray(int block, int direction)
        {
            switch (block)
            {
                case 0:
                    // ##
                    // ##
                    switch (direction)
                    {
                        case 0:
                        case 1:
                        case 2:
                        case 3:
                            return new int[2, 2] { { 1, 1 }, { 1, 1 } };
                    }
                    break;
                case 1:
                    // ####
                    switch (direction)
                    {
                        case 0:
                        case 2:
                            return new int[4, 4] { { 0, 0, 0, 0 }, { 1, 1, 1, 1 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } };
                        case 1:
                        case 3:
                            return new int[4, 4] { { 0, 0, 1, 0 }, { 0, 0, 1, 0 }, { 0, 0, 1, 0 }, { 0, 0, 1, 0 } };
                    }
                    break;
                case 2:
                    //  ##
                    // ##
                    switch (direction)
                    {
                        case 0:
                        case 2:
                            return new int[3, 3] { { 0, 0, 0 }, { 0, 1, 1 }, { 1, 1, 0 } };
                        case 1:
                        case 3:
                            return new int[3, 3] { { 0, 1, 0 }, { 0, 1, 1 }, { 0, 0, 1 } };
                    }
                    break;
                case 3:
                    // ##
                    //  ##
                    switch (direction)
                    {
                        case 0:
                        case 2:
                            return new int[3, 3] { { 0, 0, 0 }, { 1, 1, 0 }, { 0, 1, 1 } };
                        case 1:
                        case 3:
                            return new int[3, 3] { { 0, 0, 1 }, { 0, 1, 1 }, { 0, 1, 0 } };
                    }
                    break;
                case 4:
                    // ###
                    // #
                    switch (direction)
                    {
                        case 0:
                            return new int[3, 3] { { 0, 0, 0 }, { 1, 1, 1 }, { 1, 0, 0 } };
                        case 1:
                            return new int[3, 3] { { 0, 1, 0 }, { 0, 1, 0 }, { 0, 1, 1 } };
                        case 2:
                            return new int[3, 3] { { 0, 0, 1 }, { 1, 1, 1 }, { 0, 0, 0 } };
                        case 3:
                            return new int[3, 3] { { 1, 1, 0 }, { 0, 1, 0 }, { 0, 1, 0 } };
                    }
                    break;
                case 5:
                    // ###
                    //   #
                    switch (direction)
                    {
                        case 0:
                            return new int[3, 3] { { 0, 0, 0 }, { 1, 1, 1 }, { 0, 0, 1 } };
                        case 1:
                            return new int[3, 3] { { 0, 1, 1 }, { 0, 1, 0 }, { 0, 1, 0 } };
                        case 2:
                            return new int[3, 3] { { 1, 0, 0 }, { 1, 1, 1 }, { 0, 0, 0 } };
                        case 3:
                            return new int[3, 3] { { 0, 0, 1 }, { 0, 0, 1 }, { 0, 1, 1 } };
                    }
                    break;
                case 6:
                    // ###
                    //  #
                    switch (direction)
                    {
                        case 0:
                            return new int[3, 3] { { 0, 0, 0 }, { 1, 1, 1 }, { 0, 1, 0 } };
                        case 1:
                            return new int[3, 3] { { 0, 1, 0 }, { 0, 1, 1 }, { 0, 1, 0 } };
                        case 2:
                            return new int[3, 3] { { 0, 1, 0 }, { 1, 1, 1 }, { 0, 0, 0 } };
                        case 3:
                            return new int[3, 3] { { 0, 1, 0 }, { 1, 1, 0 }, { 0, 1, 0 } };
                    }
                    break;
            }

            return null;
        }



    }
}
