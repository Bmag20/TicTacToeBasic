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

        public void Move(int x, int y)
        {
            _cells[x - 1, y - 1] = 'X';  // Make it a constant
        }
    }  
}
