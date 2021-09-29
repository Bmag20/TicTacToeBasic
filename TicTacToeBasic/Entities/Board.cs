using System.IO;
using System.Linq;

namespace TicTacToeBasic.Entities
{
    public class Board
    {
        private readonly Token[,] _cells;
        private const int Size = 3;
        public Board()
        {
            _cells = new Token[Size, Size];
        }
        
        public Token[,] GetCells()
        {
            return _cells;
        }
        public int GetSize()
        {
            return Size;
        }
        public void PlaceToken(int x, int y, Token token)
        {
            if (!IsValidSlot(x, y))
                throw new InvalidDataException("Oh no, invalid slot selected!");
            if (!IsEmptySlot(x, y))
                throw new InvalidDataException($"Oh no, a piece is already at this place!");
            _cells[x - 1, y - 1] = token;
        }

        private static bool IsValidSlot(int x, int y)
        {
            return (x is > 0 and <= Size && y is > 0 and <= Size); 
        }

        private bool IsEmptySlot(int x, int y)
        {
            return (_cells[x - 1, y - 1].Equals(Token.None));
        }

        public Token[] GetColumn(int columnNumber)
        {
            return Enumerable.Range(0, Size).Select(x => _cells[x, columnNumber - 1]).ToArray();
        }

        public Token[] GetRow(int rowNumber)
        {
            return Enumerable.Range(0, Size).Select(x => _cells[rowNumber - 1, x]).ToArray();
        }
        
        public Token[] GetDiagonalLeftToRight()
        {
            return Enumerable.Range(0, Size).Select(x => _cells[x, x]).ToArray();
        }
        
        public Token[] GetDiagonalRightToLeft()
        {
            return Enumerable.Range(0, Size).Select(x => _cells[Size-1-x, x]).ToArray();
        }
    }
}
