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
    }
}