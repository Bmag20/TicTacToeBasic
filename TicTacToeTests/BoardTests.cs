using System.IO;
using TicTacToeBasic;
using TicTacToeBasic.Entities;
using Xunit;

namespace TicTacToeTests
{
    public class BoardTests
    {
        
        [Fact]
        public void Board_isOfSize3by3()
        {
            Board board = new Board();
            Assert.Equal(3, board.GetSize());
        }
        
        [Fact]
        public void NewBoard_isEmpty()
        {
            Board board = new Board();
            var result = board.GetCells();
            var expected = new Token[,]
            {
                {Token.None, Token.None, Token.None}, 
                {Token.None, Token.None, Token.None},
                {Token.None, Token.None, Token.None}
            };
            Assert.Equal(expected, result);
        }
        
        [Theory]
        [InlineData(1, 1, Token.X)]
        [InlineData(1, 2, Token.O)]
        [InlineData(3, 3, Token.X)]
        public void PlacingTokenOnEmptySlot_changesStateOfTheCell(int x, int y, Token token)
        {
            Board board = new Board();
            board.PlaceToken(x, y, token);
            var result = board.GetCells();
            Assert.Equal(token, result[x-1, y-1]);
        }

        [Fact]
        public void PlacingTokenOnOccupiedSlot_ThrowsInvalidDataException()
        {
            // Arrange
            Board board = new Board();
            board.PlaceToken(1, 1, Token.X);
            // Act and Assert
            Assert.Throws<InvalidDataException>(() => board.PlaceToken(1, 1, Token.O));
        }

        [Theory]
        [InlineData(0, 0, Token.O)]
        [InlineData(4, 4, Token.X)]
        [InlineData(-1, 2, Token.X)]
        [InlineData(1, -2, Token.X)]
        public void PlacingTokenOnInvalidSlot_ThrowsInvalidDataException(int x, int y, Token token)
        {
            Board board = new Board();
            Assert.Throws<InvalidDataException>(() => board.PlaceToken(x, y, token));
        }
        
        [Fact]
        public void GetColumn_ReturnsCorrespondingCellsFromTheColumn()
        {
            Board board = new Board();
            board.PlaceToken(1,2, Token.X);
            board.PlaceToken(2,2, Token.O);
            board.PlaceToken(3,2, Token.X);
            var actual = board.GetColumn(2);
            var expected = new Token[] {Token.X, Token.O, Token.X};
            Assert.Equal(expected, actual);
        }
 
        [Fact]
        public void GetRow_ReturnsCorrespondingCellsFromTheRow()
        {
            Board board = new Board();
            board.PlaceToken(1,1, Token.X);
            board.PlaceToken(1,2, Token.O);
            board.PlaceToken(1,3, Token.X);
            var actual = board.GetRow(1);
            var expected = new Token[] {Token.X, Token.O, Token.X};
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void GetDiagonalLeftToRight_ReturnsCorrespondingCellsFromTheDiagonal()
        {
            Board board = new Board();
            board.PlaceToken(1,1, Token.X);
            board.PlaceToken(2,2, Token.O);
            board.PlaceToken(3,3, Token.X);
            var actual = board.GetDiagonalLeftToRight();
            var expected = new Token[] {Token.X, Token.O, Token.X};
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void GetDiagonalRightToLeft_ReturnsCorrespondingCellsFromTheDiagonal()
        {
            Board board = new Board();
            board.PlaceToken(3,1, Token.X);
            board.PlaceToken(2,2, Token.O);
            board.PlaceToken(1,3, Token.X);
            var actual = board.GetDiagonalRightToLeft();
            var expected = new Token[] {Token.X, Token.O, Token.X};
            Assert.Equal(expected, actual);
        }
    }
}