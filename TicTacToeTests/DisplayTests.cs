using Moq;
using TicTacToeBasic;
using TicTacToeBasic.Entities;
using TicTacToeBasic.InputOutput;
using Xunit;

namespace TicTacToeTests
{
    public class DisplayTests
    {
        // private class MockOutputWriter: IOutputWriter
        // {
        //     public bool IsWelcomeMessageCalled { get; set; }
        //     public bool IsPrintBoardCalled { get; set; }
        //
        //     public void WelcomeMessage()
        //     {
        //         IsWelcomeMessageCalled = true;
        //     }
        //
        //     public void PrintBoard(Board board)
        //     {
        //         IsPrintBoardCalled = true;
        //     }
        // }
        
        private readonly Mock<IOutputWriter> _outputWriterMock = new Mock<IOutputWriter>();
        private readonly Mock<IInputReader> _inputReaderMock = new Mock<IInputReader>();
        private Game _ticTacToe = new Game();
        // [Fact]
        // public void WelcomeMessage1_DisplayedAtTheStartOfTheGame()
        // {
        //     GameController gameController = new GameController(_ticTacToe, _outputWriterMock.Object, _inputReaderMock.Object);
        //     gameController.StartGame();
        //     _outputWriterMock.Verify(o => o.PrintWelcomeMessage(), Times.Once);
        // }
        //
        // [Fact]
        // public void EmptyBoard_DisplayedAtTheStartOfTheGame()
        // {
        //     GameController gameController = new GameController(_ticTacToe, _outputWriterMock.Object, _inputReaderMock.Object);
        //     gameController.StartGame(); 
        //     _outputWriterMock.Verify(o => o.PrintBoard(gameController.TicTacToe.GameBoard), Times.Once);
        // }
    }
}