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
            board.Move(1, 1);
            var result = board.GetCells();
            Assert.Equal(result, new char[3,3] { {'X', '.', '.'}, {'.', '.', '.'}, {'.', '.', '.'}});
        }
        
    }
}