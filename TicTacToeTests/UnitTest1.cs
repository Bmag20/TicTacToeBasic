using Moq;
using TicTacToeBasic;
using TicTacToeBasic.Entities;
using Xunit;

namespace TicTacToeTests
{
    public class UnitTest1
    {
        private static readonly IOutputWriter OutputWriter = new ConsolePrinter();
        private static readonly IInputReader InputReader = new ConsoleReader();
        private static readonly Game TicTacToe = new Game();
        private GameController _gameController = new GameController(TicTacToe, OutputWriter, InputReader);
        
      

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


        [Fact]
        public void StartGame_SetsCurrentPlayerToPlayer1()
        {
            var inputReaderMock = new Mock<IInputReader>();
            inputReaderMock.Setup(i => i.ReadPlayerInput()).Returns("q");
            _gameController = new GameController(TicTacToe, OutputWriter, inputReaderMock.Object);
            _gameController.StartGame();
            Assert.Equal(TicTacToe.Player1, _gameController.CurrentPlayer);
        }

        // [Fact]
        // public void StartGame_AfterPlayer1Turn_SetsCurrentPlayerToPlayer2()
        // {
        //     var inputReaderMock = new Mock<IInputReader>();
        //     inputReaderMock.Setup(i => i.ReadPlayerInput()).Returns("1,1");
        //     _gameController = new GameController(TicTacToe, OutputWriter, inputReaderMock.Object);
        //     _gameController.StartGame();
        //     Assert.Equal(TicTacToe.Player2, _gameController.CurrentPlayer);
        // }

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
        public void IsWinner_OnNewBoard_ReturnsFalse()
        {
            // Arrange
            Board board = new Board();
            Player player = new Player(Token.X);
            // Act
            var result = WinDecider.IsWinner(board, player);
            // Assert
            Assert.False(result);
        }

        private static void PlaceTokenOnColumn(Board board, Player player, int column)
        {
            for (int i = 1; i <= board.GetSize(); i++)
            {
                board.PlaceToken(i,column, player.PlayerToken);
            }
        }
        
        private static void PlaceTokenOnRow(Board board, Player player, int row)
        {
            for (int i = 1; i <= board.GetSize(); i++)
            {
                board.PlaceToken(row, i, player.PlayerToken);
            }
        }
        
        private static void PlaceTokenOnLeftToRightDiagonal(Board board, Player player)
        {
            board.PlaceToken(1, 1, player.PlayerToken);
            board.PlaceToken(2, 2, player.PlayerToken);
            board.PlaceToken(3, 3, player.PlayerToken);
        }
        
        private static void PlaceTokenOnRightToLeftDiagonal(Board board, Player player)
        {
            board.PlaceToken(1, 3, player.PlayerToken);
            // board.PlaceToken(3, 1, player2.PlayerToken);
            board.PlaceToken(2, 2, player.PlayerToken);
            board.PlaceToken(3, 1, player.PlayerToken);
        }
        
        [Fact]
        public void IsWinner_SameTokenInFirstColumn_ReturnsTrue()
        {
            // Arrange
            Board board = new Board();
            Player player = new Player(Token.X);
            PlaceTokenOnColumn(board, player, 1);
            // Act
            var result = WinDecider.IsWinner(board, player);
            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsWinner_SameTokenInThirdColumn_ReturnsTrue()
        {
            // Arrange
            Board board = new Board();
            Player player = new Player(Token.O);
            PlaceTokenOnColumn(board, player, 3);
            // Act
            var result = WinDecider.IsWinner(board, player);
            // Assert
            Assert.True(result);
        }
        
        [Fact]
        public void IsWinner_SameTokenInFirstRow_ReturnsTrue()
        {
            // Arrange
            Board board = new Board();
            Player player = new Player(Token.O);
            PlaceTokenOnRow(board, player, 1);
            // Act
            var result = WinDecider.IsWinner(board, player);
            // Assert
            Assert.True(result);
        }
        
        [Fact]
        public void IsWinner_SameTokenInThirdRow_ReturnsTrue()
        {
            // Arrange
            Board board = new Board();
            Player player = new Player(Token.X);
            PlaceTokenOnRow(board, player, 3);
            // Act
            var result = WinDecider.IsWinner(board, player);
            // Assert
            Assert.True(result);
        }
        
        [Fact]
        public void IsWinner_SameTokenInLeftToRightDiagonal_ReturnsTrue()
        {
            // Arrange
            Board board = new Board();
            Player player = new Player(Token.X);
            PlaceTokenOnLeftToRightDiagonal(board, player);
            // Act
            var result = WinDecider.IsWinner(board, player);
            // Assert
            Assert.True(result);
        }
        
        [Fact]
        public void IsWinner_SameTokenInRightToLeftDiagonal_ReturnsTrue()
        {
            // Arrange
            Board board = new Board();
            Player player = new Player(Token.X);
            PlaceTokenOnRightToLeftDiagonal(board, player);
            // Act
            var result = WinDecider.IsWinner(board, player);
            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsEndOfGame()
        {
            // Arrange
            Board board = new Board();
            
            
        }
        
        
    }


}