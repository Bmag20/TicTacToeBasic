using TicTacToeBasic;
using Xunit;

namespace TicTacToeTests
{
    public class UnitTest1
    {
        [Fact]
        public void New_board_is_empty()
        {
            Board board = new Board();
            var result = board.GetCells();
            Assert.Equal(result, new char[,]{{'.', '.', '.'}, {'.', '.', '.'}, {'.', '.', '.'}});
        }
        
        [Fact]
        public void Player1_selecting_empty_slot_on_board_changes_the_slot_with_player1_token()
        {
            Board board = new Board();
            board.Move(1, 1, 'X');
            var result = board.GetCells();
            Assert.Equal(result, new char[3,3] { {'X', '.', '.'}, {'.', '.', '.'}, {'.', '.', '.'}});
        }
        
        [Fact]
        public void Player2_selecting_empty_slot_on_board_changes_the_slot_with_player2_token()
        {
            Board board = new Board();
            board.Move(1, 1, 'O');
            var result = board.GetCells();
            Assert.Equal(result, new char[3,3] { {'O', '.', '.'}, {'.', '.', '.'}, {'.', '.', '.'}});
        }
        
        [Fact]
        public void Player_selecting_occupied_slot_does_not_change_the_board()
        {
            // Arrange
            Board board = new Board();
            board.Move(1, 1, 'X');
            var firstBoard = (char[,])board.GetCells().Clone();
            // Act
            board.Move(1, 1, 'O');
            var actualBoard = (char[,])board.GetCells().Clone();
            // Assert
            Assert.Equal(firstBoard, actualBoard);
        }
        
        [Fact]
        public void Player_selecting_invalid_slot_does_not_change_the_board()
        {
            // Arrange
            Board board = new Board();
            var firstBoard = (char[,])board.GetCells().Clone();
            // Act
            board.Move(1, 5, 'O');
            var actualBoard = (char[,])board.GetCells().Clone();
            // Assert
            Assert.Equal(firstBoard, actualBoard);
        }
        
        
    }
}