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
        private static readonly Board Board = new();
        private static readonly Player Player1 = new(Token.X, "Player 1");
        private static readonly Player Player2 = new(Token.O, "Player 2");
        private static Game _ticTacToe = new Game(Board, Player1, Player2);
        private GameController _gameController = new(_ticTacToe, OutputWriter, InputReader);
        
        [Fact]
        public void GameInitialisation_SetsCurrentPlayerToPlayer1()
        {
            var ticTacToe = new Game(Board, Player1, Player2);
            Assert.Equal(ticTacToe.Player1, ticTacToe.CurrentPlayer);
        }
        
        [Fact]
        public void StartGame_FirstValidInput_UpdatesBoardWithPlayer1Token()
        {
            var inputReaderMock = new Mock<IInputReader>();
            inputReaderMock.SetupSequence(i => i.ReadPlayerInput()).Returns("1,1").Returns("q");
            _ticTacToe = new Game(Board, Player1, Player2);
            _gameController = new GameController(_ticTacToe, OutputWriter, inputReaderMock.Object);
            _gameController.ConductGame();
            Assert.Equal(_ticTacToe.Player1.PlayerToken, _ticTacToe.GameBoard.GetCells()[0, 0]);
        }
        
        [Fact]
        public void StartGame_AfterPlayer1Turn_SetsCurrentPlayerToPlayer2()
        {
            var inputReaderMock = new Mock<IInputReader>();
            inputReaderMock.SetupSequence(i => i.ReadPlayerInput()).Returns("1,1").Returns("q");
            var board = new Board();
            _ticTacToe = new Game(board, Player1, Player2);
            _gameController = new GameController(_ticTacToe, OutputWriter, inputReaderMock.Object);
            _gameController.ConductGame();
            Assert.Equal(_ticTacToe.Player2, _ticTacToe.CurrentPlayer);
        }

        [Fact]
        public void StartGame_WhenPlayerInputsQ_CallsPrintPlayerQuitMessage()
        {
            // Arrange
            var inputReaderMock = new Mock<IInputReader>();
            inputReaderMock.SetupSequence(i => i.ReadPlayerInput()).Returns("q");
            var outputWriterMock = new Mock<IOutputWriter>();
            _ticTacToe = new Game(Board, Player1, Player2);
            _gameController = new GameController(_ticTacToe, outputWriterMock.Object, inputReaderMock.Object);
            // Act
            _gameController.ConductGame();
            // Assert
            outputWriterMock.Verify(o => o.PlayerQuit(), Times.Once);
        }
        
        [Fact]
        public void StartGame_WhenPlayerInputsQ_SetsIsEndedToTrue()
        {
            // Arrange
            var inputReaderMock = new Mock<IInputReader>();
            inputReaderMock.SetupSequence(i => i.ReadPlayerInput()).Returns("q");
            _ticTacToe = new Game(Board, Player1, Player2);
            _gameController = new GameController(_ticTacToe, OutputWriter, inputReaderMock.Object);
            // Act
            _gameController.ConductGame();
            // Assert
            Assert.True(_ticTacToe.IsEnded());
        }
        
        [Fact]
        public void StartGame_WhenPlayerInputsQ_SetsWinnerToOtherPlayer()
        {
            // Arrange
            var inputReaderMock = new Mock<IInputReader>();
            inputReaderMock.SetupSequence(i => i.ReadPlayerInput()).Returns("q");
            _ticTacToe = new Game(Board, Player1, Player2);
            _gameController = new GameController(_ticTacToe, OutputWriter, inputReaderMock.Object);
            // Act
            _gameController.ConductGame();
            // Assert
            Assert.Equal(_ticTacToe.Player2, _ticTacToe.Winner);
        }
        
        [Fact]
        public void StartGame_UserInputsOccupiedPlace_PrintsErrorMessage()
        {
            // Arrange
            var inputReaderMock = new Mock<IInputReader>();
            inputReaderMock.SetupSequence(i => i.ReadPlayerInput()).Returns("1,1")
                .Returns("1,1").Returns("q");
            var outputWriterMock = new Mock<IOutputWriter>();
            var board = new Board();
            _ticTacToe = new Game(board, Player1, Player2);
            _gameController = new GameController(_ticTacToe, outputWriterMock.Object, inputReaderMock.Object);
            // Act
            _gameController.ConductGame();
            // Assert
            const string expectedErrorMessage = "Oh no, a piece is already at this place!";
            outputWriterMock.Verify(ow => ow.ErrorPrompt(expectedErrorMessage), Times.Once);
        }

        [Fact]
        public void StartGame_UserInputsInvalidPlace_PrintsErrorMessage()
        {
            // Arrange
            var inputReaderMock = new Mock<IInputReader>();
            inputReaderMock.SetupSequence(i => i.ReadPlayerInput()).Returns("5,5").Returns("q");
            var outputWriterMock = new Mock<IOutputWriter>();
            var board = new Board();
            _ticTacToe = new Game(board, Player1, Player2);
            _gameController = new GameController(_ticTacToe, outputWriterMock.Object, inputReaderMock.Object);
            // Act
            _gameController.ConductGame();
            // Assert
            const string expectedErrorMessage = "Oh no, invalid slot selected!";
            outputWriterMock.Verify(ow => ow.ErrorPrompt(expectedErrorMessage), Times.Once);
        }
        
        [Fact]
        public void StartGame_UserInputsInvalidFormat_PrintsErrorMessage()
        {
            // Arrange
            var inputReaderMock = new Mock<IInputReader>();
            inputReaderMock.SetupSequence(i => i.ReadPlayerInput()).Returns("abc").Returns("q");
            var outputWriterMock = new Mock<IOutputWriter>();
            var board = new Board();
            _ticTacToe = new Game(board, Player1, Player2);
            _gameController = new GameController(_ticTacToe, outputWriterMock.Object, inputReaderMock.Object);
            // Act
            _gameController.ConductGame();
            // Assert
            const string expectedErrorMessage = "Invalid Input!!";
            outputWriterMock.Verify(ow => ow.ErrorPrompt(expectedErrorMessage), Times.Once);
        }
        
        [Fact]
        public void StartGame_ValidInputAfterInvalidInput_UpdatesBoardWithSamePlayerToken()
        {
            var inputReaderMock = new Mock<IInputReader>();
            inputReaderMock.SetupSequence(i => i.ReadPlayerInput())
                .Returns("abc").Returns("1,1").Returns("q");
            _ticTacToe = new Game(Board, Player1, Player2);
            _gameController = new GameController(_ticTacToe, OutputWriter, inputReaderMock.Object);
            _gameController.ConductGame();
            Assert.Equal(_ticTacToe.Player1.PlayerToken, _ticTacToe.GameBoard.GetCells()[0, 0]);
        }
        
        [Fact]
        public void StartGame_WhenPlayerWins_IsEndedReturnsTrue()
        {
            // Arrange
            var inputReaderMock = new Mock<IInputReader>();
            inputReaderMock.SetupSequence(i => i.ReadPlayerInput())
                .Returns("1,1").Returns("1,2").Returns("2,1").Returns("2,2").Returns("3,1");
            var board = new Board();
            _ticTacToe = new Game(board, Player1, Player2);
            _gameController = new GameController(_ticTacToe, OutputWriter, inputReaderMock.Object);
            // Act
            _gameController.ConductGame();
            // Assert
            Assert.True(_ticTacToe.IsEnded());
        }
        
        [Fact]
        public void StartGame_WhenPlayerWins_WinnerIsAssigned()
        {
            // Arrange
            var inputReaderMock = new Mock<IInputReader>();
            inputReaderMock.SetupSequence(i => i.ReadPlayerInput())
                .Returns("1,1").Returns("1,2").Returns("2,1").Returns("2,2").Returns("3,1");
            var board = new Board();
            _ticTacToe = new Game(board, Player1, Player2);
            _gameController = new GameController(_ticTacToe, OutputWriter, inputReaderMock.Object);
            // Act
            _gameController.ConductGame();
            // Assert
            Assert.Equal(_ticTacToe.Player1, _ticTacToe.Winner);
        }

        [Fact]
        public void StartGame_WhenBoardIsFull_SetsIsEndedToTrue()
        {
            // Arrange
            var board = new Board();
            FillBoardWithoutAWin(board);
            _ticTacToe = new Game(board, Player1, Player2);
            _gameController = new GameController(_ticTacToe, OutputWriter, InputReader);
            // Act
            _gameController.ConductGame();
            // Assert
            Assert.True(_ticTacToe.IsEnded());
        }
        
        [Fact]
        public void StartGame_WhenBoardIsFull_BoardIsFullIsPrinted()
        {
            // Arrange
            var board = new Board();
            FillBoardWithoutAWin(board);
            _ticTacToe = new Game(board, Player1, Player2);
            var outputWriterMock = new Mock<IOutputWriter>();
            _gameController = new GameController(_ticTacToe, outputWriterMock.Object, InputReader);
            // Act
            _gameController.ConductGame();
            // Assert
            outputWriterMock.Verify(ow => ow.BoardIsFull(), Times.Once);
        }
        
        private static void FillBoardWithoutAWin(Board board)
        {
            board.PlaceToken(1, 1, Token.X);
            board.PlaceToken(1, 2, Token.O);
            board.PlaceToken(1, 3, Token.X);
            board.PlaceToken(2, 1, Token.O);
            board.PlaceToken(2, 2, Token.X);
            board.PlaceToken(2, 3, Token.O);
            board.PlaceToken(3, 1, Token.X);
            board.PlaceToken(3, 2, Token.O);
            board.PlaceToken(3, 3, Token.X);
        }
    }
}