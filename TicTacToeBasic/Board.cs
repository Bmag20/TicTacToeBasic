namespace TicTacToeBasic
{
    public class Board
    {
        private Token[,] _cells;
        public int Size { get; set; }
        public Board(int size)
        {
            Size = size;
            _cells = new Token[Size, Size];
        }
        
        public Token[,] GetCells()
        {
            return _cells;
        }

        public void PlaceToken(int x, int y, Token token)
        {
            if (IsValidSlot(x, y) && IsEmptySlot(x, y))
                _cells[x - 1, y - 1] = token;
        }

        private static bool IsValidSlot(int x, int y)
        {
            return (x is > 0 and <= 3 && y is > 0 and <= 3); // use constants
        }

        private bool IsEmptySlot(int x, int y)
        {
            return (_cells[x - 1, y - 1].Equals(Token.None));
        }
        
    }
}
