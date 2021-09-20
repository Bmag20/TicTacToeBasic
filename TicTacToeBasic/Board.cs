using System.Runtime.CompilerServices;

namespace TicTacToeBasic
{
    public class Board
    {
        private char[,] _cells;

        public Board()
        {
            _cells = new char[,]{{'.', '.', '.'}, {'.', '.', '.'}, {'.', '.', '.'}};
        }
        public char[,] GetCells()
        {
            return _cells;
        }

        public void Move(int x, int y, char token)
        {
            if (IsValidSlot(x, y) && IsEmptySlot(x, y))
                _cells[x - 1, y - 1] = token;
        }

        private static bool IsValidSlot(int x, int y)
        {
            return (x is > 0 and <= 3 && y is > 0 and <= 3);
        }

        private bool IsEmptySlot(int x, int y)
        {
            return (_cells[x - 1, y - 1].Equals('.'));
        }
    }  
}
