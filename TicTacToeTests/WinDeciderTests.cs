using TicTacToeBasic.Entities;
using TicTacToeBasic.TicTacToeControl;
using Xunit;

namespace TicTacToeTests
{
    public class WinDeciderTests
    {
        [Fact]
        public void IsWinner_OnNewBoard_ReturnsFalse()
        {
            // Arrange
            Board board = new Board();
            Player player = new Player(Token.X, "Player 1");
            // Act
            var result = WinDecider.IsWinner(board, player);
            // Assert
            Assert.False(result);
        }

       

        [Fact]
        public void IsWinner_SameTokenInFirstColumn_ReturnsTrue()
        {
            // Arrange
            Board board = new Board();
            Player player = new Player(Token.X, "Player 1");
            PlaceTokenOnColumn(board, player, 1);
            // Act
            var result = WinDecider.IsWinner(board, player);
            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsWinner_SameTokenInThirdColumn_ReturnsTrue()
        {
            // Arrange
            Board board = new Board();
            Player player = new Player(Token.O, "Player 1");
            PlaceTokenOnColumn(board, player, 3);
            // Act
            var result = WinDecider.IsWinner(board, player);
            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsWinner_SameTokenInFirstRow_ReturnsTrue()
        {
            // Arrange
            Board board = new Board();
            Player player = new Player(Token.O, "Player 1");
            PlaceTokenOnRow(board, player, 1);
            // Act
            var result = WinDecider.IsWinner(board, player);
            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsWinner_SameTokenInThirdRow_ReturnsTrue()
        {
            // Arrange
            Board board = new Board();
            Player player = new Player(Token.X, "Player 1");
            PlaceTokenOnRow(board, player, 3);
            // Act
            var result = WinDecider.IsWinner(board, player);
            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsWinner_SameTokenInLeftToRightDiagonal_ReturnsTrue()
        {
            // Arrange
            Board board = new Board();
            Player player = new Player(Token.X, "Player 1");
            PlaceTokenOnLeftToRightDiagonal(board, player);
            // Act
            var result = WinDecider.IsWinner(board, player);
            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsWinner_SameTokenInRightToLeftDiagonal_ReturnsTrue()
        {
            // Arrange
            Board board = new Board();
            Player player = new Player(Token.X, "Player 1");
            PlaceTokenOnRightToLeftDiagonal(board, player);
            // Act
            var result = WinDecider.IsWinner(board, player);
            // Assert
            Assert.True(result);
        }
        
        private static void PlaceTokenOnColumn(Board board, Player player, int column)
        {
            for (int i = 1; i <= board.GetSize(); i++)
            {
                board.PlaceToken(i, column, player.PlayerToken);
            }
        }

        private static void PlaceTokenOnRow(Board board, Player player, int row)
        {
            for (int i = 1; i <= board.GetSize(); i++)
            {
                board.PlaceToken(row, i, player.PlayerToken);
            }
        }

        private static void PlaceTokenOnLeftToRightDiagonal(Board board, Player player)
        {
            board.PlaceToken(1, 1, player.PlayerToken);
            board.PlaceToken(2, 2, player.PlayerToken);
            board.PlaceToken(3, 3, player.PlayerToken);
        }

        private static void PlaceTokenOnRightToLeftDiagonal(Board board, Player player)
        {
            board.PlaceToken(1, 3, player.PlayerToken);
            board.PlaceToken(2, 2, player.PlayerToken);
            board.PlaceToken(3, 1, player.PlayerToken);
        }
    }
}