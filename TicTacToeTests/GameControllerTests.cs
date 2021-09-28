using Moq;
using TicTacToeBasic;
using TicTacToeBasic.InputOutput;
using Xunit;

namespace TicTacToeTests
{
    public class GameControllerTests
    {
        private static readonly IOutputWriter OutputWriter = new ConsolePrinter();
        private static readonly IInputReader InputReader = new ConsoleReader();
        private static Game _ticTacToe = new Game();
        private GameController _gameController = new GameController(_ticTacToe, OutputWriter, InputReader);
        
        // System of unit - taking turns
        // What the test is testing? - expectation
        
        // When game is first initialised, player 1 gets to play
        // init game 
        // game.play(1, 2)
        // expect the game state or board to change with token

        // After first player makes a move, player 2 gets to play
        // game init
        // player places a token
        // then something happns - take turns
        // player 2 players
        

        // [Fact]
        //
        // public void foo()
        // {
        //     IOutputWriter outputWriter = new ConsolePrinter();
        //     IInputReader inputReader = new ConsoleReader();
        //     inputReader.setMockData(["1,2", "3,3", "4,3"])
        //     Game g = new Game(outputWriter, inputReader);
        //     g.Start();
        //     Mock(inputReader, first).thenreturn()
        //     // set/Moq user input in console reader and check the value of cell
        //
        // }
        [Fact]
        public void FirstRound_isPlayer1Turn()
        {
            // Arrange
            _gameController.TicTacToe.Round = 1;
            // Act
            var result = _gameController.IsPlayerOneTurn();
            // Assert
            Assert.True(result);
        }
        
        [Fact]
        public void OddRounds_arePlayer1Turns()
        {
            // Arrange
            _gameController.TicTacToe.Round = 5;
            // Act
            var result = _gameController.IsPlayerOneTurn();
            // Assert
            Assert.True(result);
        }
        
        [Fact]
        public void EvenRounds_arePlayer2Turns()
        {
            // Arrange
            _gameController.TicTacToe.Round = 2;
            // Act
            var result = _gameController.IsPlayerOneTurn();
            // Assert
            Assert.False(result);
        }
 
        [Fact]
        public void StartGame_SetsCurrentPlayerToPlayer1()
        {
            var inputReaderMock = new Mock<IInputReader>();
            inputReaderMock.Setup(i => i.ReadPlayerInput()).Returns("q");
            _ticTacToe = new Game();
            _gameController = new GameController(_ticTacToe, OutputWriter, inputReaderMock.Object);
            _gameController.StartGame();
            Assert.Equal(_ticTacToe.Player1, _gameController.CurrentPlayer);
        }

        [Fact]
        public void StartGame_AfterPlayer1Turn_SetsCurrentPlayerToPlayer2()
        {
            var inputReaderMock = new Mock<IInputReader>();
            inputReaderMock.SetupSequence(i => i.ReadPlayerInput()).Returns("1,1").Returns("q");
            _ticTacToe = new Game();
            _gameController = new GameController(_ticTacToe, OutputWriter, inputReaderMock.Object);
            _gameController.StartGame();
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
            _gameController.StartGame();
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
            _gameController.StartGame();
            // Assert
            Assert.True(_ticTacToe.IsEnded);
        }
        
        [Fact]
        public void StartGame_WhenBoardIsFull_SetsIsEndedToTrue()
        {
            // Arrange
            var inputReaderMock = new Mock<IInputReader>();
            inputReaderMock.SetupSequence(i => i.ReadPlayerInput())
                .Returns("1,1");
            _ticTacToe = new Game
            {
                Round = 9
            };
            _gameController = new GameController(_ticTacToe, OutputWriter, inputReaderMock.Object);
            // Act
            _gameController.StartGame();
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
            _gameController.StartGame();
            // Assert
            Assert.True(_ticTacToe.IsEnded);
        }

        [Fact]
        public void StartGame1_WhenBoardIsFull_SetsIsEndedToTrue()
        {
            // Arrange
            var inputReaderMock = new Mock<IInputReader>();
            inputReaderMock.SetupSequence(i => i.ReadPlayerInput())
                .Returns("1,1").Returns("1,2").Returns("2,1").Returns("2,2").Returns("3,1");
            _ticTacToe = new Game();
            _gameController = new GameController(_ticTacToe, OutputWriter, inputReaderMock.Object);
            // Act
            _gameController.StartGame();
            // Assert
            Assert.True(_ticTacToe.IsEnded);
        }
    }
}