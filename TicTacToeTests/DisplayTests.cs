using Moq;
using TicTacToeBasic;
using Xunit;

namespace TicTacToeTests
{
    public class DisplayTests
    {
        private class MockOutputWriter: IOutputWriter
        {
            public bool IsWelcomeMessageCalled { get; set; }
            public bool IsPrintBoardCalled { get; set; }

            public void PrintWelcomeMessage()
            {
                IsWelcomeMessageCalled = true;
            }

            public void PrintBoard(Board board)
            {
                IsPrintBoardCalled = true;
            }
        }
        
        private readonly Mock<IOutputWriter> _outputWriterMock = new Mock<IOutputWriter>();
        private readonly Mock<IInputReader> _inputReaderMock = new Mock<IInputReader>();
        [Fact]
        public void WelcomeMessage1_DisplayedAtTheStartOfTheGame()
        {
            Game game = new Game(_outputWriterMock.Object, _inputReaderMock.Object);
            game.Start();
            _outputWriterMock.Verify(o => o.PrintWelcomeMessage(), Times.Once);
        }
 
        [Fact]
        public void EmptyBoard_DisplayedAtTheStartOfTheGame()
        {
            Game game = new Game(_outputWriterMock.Object, _inputReaderMock.Object);
            game.Start(); 
            _outputWriterMock.Verify(o => o.PrintBoard(game.GameBoard), Times.Once);
        }
    }
}