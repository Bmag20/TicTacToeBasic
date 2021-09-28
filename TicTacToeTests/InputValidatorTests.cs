using TicTacToeBasic.InputOutput;
using Xunit;

namespace TicTacToeTests
{
    public class InputValidatorTests
    {
        [Theory]
        [InlineData("1,1")]
        [InlineData("3,3")]
        [InlineData("0,0")]
        [InlineData("8,8")]
        public void IsValid_ValidFormatInput_ReturnsTrue(string input)
        {
            Assert.True(InputValidator.IsValidInputFormat(input));
        }
        
        [Theory]
        [InlineData("11")]
        [InlineData("X")]
        [InlineData("q")]
        [InlineData("Q")]
        [InlineData("quit")]
        public void IsValid_InvalidInputFormat_ReturnsFalse(string input)
        {
            Assert.False(InputValidator.IsValidInputFormat(input));
        }
        
        [Theory]
        [InlineData("q")]
        [InlineData("Q")]
        [InlineData("quit")]
        public void IsQuit_QuitInput_ReturnsTrue(string input)
        {
            Assert.True(InputValidator.IsQuit(input));
        }

        [Theory]
        [InlineData("1,1")]
        [InlineData("8,8")]
        [InlineData("11")]
        [InlineData("X")]
        public void IsQuit_NotQuitInput_ReturnsFalse(string input)
        {
            Assert.False(InputValidator.IsQuit(input));
        }
    }
}