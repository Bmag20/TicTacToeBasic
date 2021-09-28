using Moq;
using TicTacToeBasic.Entities;
using TicTacToeBasic.InputOutput;
using TicTacToeBasic.TicTacToeControl;
using Xunit;

namespace TicTacToeTests
{
    public class GameControllerTests
    {
        private static readonly IOutputWriter OutputWriter = new ConsolePrinter();
        private static readonly IInputReader InputReader = new ConsoleReader();
        private static Game _ticTacToe = new Game();
        private GameController _gameController = new GameController(_ticTacToe, OutputWriter, InputReader);


        [Fact]
        public void StartGame_SetsCurrentPlayerToPlayer1()
        {
            var inputReaderMock = new Mock<IInputReader>();
            inputReaderMock.Setup(i => i.ReadPlayerInput()).Returns("q");
            _ticTacToe = new Game();
            _gameController = new GameController(_ticTacToe, OutputWriter, inputReaderMock.Object);
            _gameController.ConductGame();
            Assert.Equal(_ticTacToe.Player1, _gameController.CurrentPlayer);
        }
        
        [Fact]
        public void StartGame_FirstValidInput_UpdatesBoardWithPlayer1Token()
        {
            var inputReaderMock = new Mock<IInputReader>();
            inputReaderMock.SetupSequence(i => i.ReadPlayerInput()).Returns("1,1").Returns("q");
            _ticTacToe = new Game();
            _gameController = new GameController(_ticTacToe, OutputWriter, inputReaderMock.Object);
            _gameController.ConductGame();
            Assert.Equal(_ticTacToe.Player1.PlayerToken, _ticTacToe.GameBoard.GetCells()[0, 0]);
        }
        
        // Invalid input? - ask player to enter inout again
        
        [Fact]
        public void StartGame_AfterPlayer1Turn_SetsCurrentPlayerToPlayer2()
        {
            var inputReaderMock = new Mock<IInputReader>();
            inputReaderMock.SetupSequence(i => i.ReadPlayerInput()).Returns("1,1").Returns("q");
            _ticTacToe = new Game();
            _gameController = new GameController(_ticTacToe, OutputWriter, inputReaderMock.Object);
            _gameController.ConductGame();
            Assert.Equal(_ticTacToe.Player2, _gameController.CurrentPlayer);
        }

        [Fact]
        public void StartGame_WhenPlayerInputsQ_CallsPrintPlayerQuitMessage()
        {
            // Arrange
            var inputReaderMock = new Mock<IInputReader>();
            inputReaderMock.SetupSequence(i => i.ReadPlayerInput()).Returns("q");
            var outputWriterMock = new Mock<IOutputWriter>();
            _ticTacToe = new Game();
            _gameController = new GameController(_ticTacToe, outputWriterMock.Object, inputReaderMock.Object);
            // Act
            _gameController.ConductGame();
            // Assert
            outputWriterMock.Verify(o => o.PlayerQuit("Player 1"), Times.Once);
        }
        
        [Fact]
        public void StartGame_WhenPlayerInputsQ_SetsIsEndedToTrue()
        {
            // Arrange
            var inputReaderMock = new Mock<IInputReader>();
            inputReaderMock.SetupSequence(i => i.ReadPlayerInput()).Returns("q");
            _ticTacToe = new Game();
            _gameController = new GameController(_ticTacToe, OutputWriter, inputReaderMock.Object);
            // Act
            _gameController.ConductGame();
            // Assert
            Assert.True(_ticTacToe.IsEnded);
        }
        
        
        [Fact]
        public void StartGame_WhenPlayerWins_SetsIsEndedToTrue()
        {
            // Arrange
            var inputReaderMock = new Mock<IInputReader>();
            inputReaderMock.SetupSequence(i => i.ReadPlayerInput())
                .Returns("1,1").Returns("1,2").Returns("2,1").Returns("2,2").Returns("3,1");
            _ticTacToe = new Game();
            _gameController = new GameController(_ticTacToe, OutputWriter, inputReaderMock.Object);
            // Act
            _gameController.ConductGame();
            // Assert
            Assert.True(_ticTacToe.IsEnded);
        }

        [Fact]
        public void StartGame1_WhenBoardIsFull_SetsIsEndedToTrue()
        {
            // Arrange
            var inputReaderMock = new Mock<IInputReader>();
            inputReaderMock.SetupSequence(i => i.ReadPlayerInput())
                .Returns("1,1").Returns("1,2").Returns("2,1").Returns("2,2").Returns("3,2")
                .Returns("3,1").Returns("1,3").Returns("3,3").Returns("2,3").Returns("3,1");
            _ticTacToe = new Game();
            _gameController = new GameController(_ticTacToe, OutputWriter, inputReaderMock.Object);
            // Act
            _gameController.ConductGame();
            // Assert
            Assert.True(_ticTacToe.IsEnded);
        }
        
        [Fact]
        public void StartGame1_WhenBoardIsFull_BoardIsFullIsPrinted()
        {
            // Arrange
            var inputReaderMock = new Mock<IInputReader>();
            inputReaderMock.SetupSequence(i => i.ReadPlayerInput())
                .Returns("1,1").Returns("1,2").Returns("2,1").Returns("2,2").Returns("3,2")
                .Returns("3,1").Returns("1,3").Returns("3,3").Returns("2,3").Returns("3,1");
            var outputWriterMock = new Mock<IOutputWriter>();
            _ticTacToe = new Game();
            _gameController = new GameController(_ticTacToe, outputWriterMock.Object, inputReaderMock.Object);
            // Act
            _gameController.ConductGame();
            // Assert
            outputWriterMock.Verify(o => o.BoardIsFull(), Times.Once);
        }
    }
}