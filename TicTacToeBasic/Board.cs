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
    }  
}
