using Moq;
using TicTacToeBasic;
using Xunit;

namespace TicTacToeTests
{
    public class UnitTest1
    {
        private static readonly IOutputWriter OutputWriter = new ConsolePrinter();
        private static readonly IInputReader InputReader = new ConsoleReader();
        readonly Game game = new Game(OutputWriter, InputReader);
        
        // Size of the board - delete
        [Fact]
        public void Board_isOfSize3by3()
        {
            Board board = new Board(3);
            Assert.Equal(3, board.GetCells().GetLength(0));
            Assert.Equal(3, board.GetCells().GetLength(1));
        }
        
        [Fact]
        public void NewBoard_isEmpty()
        {
            Board board = new Board(3);
            var result = board.GetCells();
            // compare 2d array
            Assert.Equal(Token.None, result[0, 0]);
        }
        
        [Fact]
        public void PlacingTokenOnEmptySlot_changesStateOfTheCell()
        {
            Board board = new Board(3);
            board.PlaceToken(1, 1, Token.X);
            var result = board.GetCells();
            Assert.Equal(Token.X, result[0, 0]);
        }

        [Fact]
        public void PlacingTokenOnOccupiedSlot_doesNotChangeStateOfTheCell()
        {
            // Arrange
            Board board = new Board(3);
            board.PlaceToken(1, 1, Token.X);
            var firstBoard = (Token[,])board.GetCells().Clone();
            // Act
            board.PlaceToken(1, 1, Token.O);
            var actualBoard = (Token[,])board.GetCells().Clone();
            // Assert
            Assert.Equal(firstBoard, actualBoard);
        }
        
        // add boundary case
        
        [Fact]
        public void PlacingTokenOnInvalidSlot_doesNotChangeStateOfTheCell()
        {
            // Arrange
            Board board = new Board(3);
            var firstBoard = (Token[,])board.GetCells().Clone();
            // Act
            board.PlaceToken(1, 5, Token.O);
            var actualBoard = (Token[,])board.GetCells().Clone();
            // Assert
            Assert.Equal(firstBoard, actualBoard);
        }

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
        //     IInputReader inputReader = new TestConsoleReader();
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
            game.State.Round = 1;
            // Act
            var result = game.IsPlayerOneTurn();
            // Assert
            Assert.True(result);
        }
        
        [Fact]
        public void OddRounds_arePlayer1Turns()
        {
            // Arrange
            game.State.Round = 5;
            // Act
            var result = game.IsPlayerOneTurn();
            // Assert
            Assert.True(result);
        }
        
        [Fact]
        public void EvenRounds_arePlayer2Turns()
        {
            // Arrange
            game.State.Round = 2;
            // Act
            var result = game.IsPlayerOneTurn();
            // Assert
            Assert.False(result);
        }
 


        [Fact]
        public void IsWin_TokenXInFirstColumn_ReturnsTokenX()
        {
            // Arrange
            Board board = new Board(3);
            board.PlaceToken(1, 1, Token.X);
            board.PlaceToken(2, 1, Token.X);
            board.PlaceToken(3, 1, Token.X);
            // Act
            var winningToken = Determiner.IsWin(board);
            // Assert
            Assert.Equal(Token.X, winningToken);
        }

        
    }


}