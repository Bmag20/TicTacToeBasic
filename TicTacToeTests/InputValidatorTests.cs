using TicTacToeBasic;
using TicTacToeBasic.InputOutput;
using Xunit;

namespace TicTacToeTests
{
    public class InputValidatorTests
    {
        [Theory]
        [InlineData("1,1")]
        [InlineData("3,3")]
        [InlineData("q")]
        [InlineData("Q")]
        [InlineData("quit")]
        public void IsValid_InputCoordBetween1And3OrQ_ReturnsTrue(string value)
        {
            Assert.True(InputValidator.IsValidInput(value));
        }

        [Theory]
        [InlineData("0,0")]
        [InlineData("3,4")]
        [InlineData("X")]
        public void IsValid_InputNotValidCoordOrQ_ReturnsFalse(string value)
        {
            Assert.False(InputValidator.IsValidInput(value));
        }
    }
}