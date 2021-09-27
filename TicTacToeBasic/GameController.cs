using System.ComponentModel;
using TicTacToeBasic.Entities;

namespace TicTacToeBasic
{
    public class GameController
    {
        public Game TicTacToe { get; set; }
        private IOutputWriter _outputWriter;
        private IInputReader _inputReader;
        public Player CurrentPlayer { get; private set; }


        public GameController(Game game, IOutputWriter outputWriter, IInputReader inputReader)
        {
            TicTacToe = game;
            _outputWriter = outputWriter;
            _inputReader = inputReader;
        }

        public void StartGame()
        {
            _outputWriter.PrintWelcomeMessage();
            _outputWriter.PrintBoard(TicTacToe.GameBoard);
            CurrentPlayer = TicTacToe.Player1;
            var input = _inputReader.ReadPlayerInput();
            if (!input.Equals("q"))
            {
                TicTacToe.GameBoard.PlaceToken(input[0], input[2], Token.X);
                CurrentPlayer = TicTacToe.Player2;
            }

        }

        // private void ConductTurn()
        // {
        //     var input = _inputReader.ReadPlayerInput();
        //     TicTacToe.GameBoard.PlaceToken(input[0], input[2], Token.X);
        //     CurrentPlayer = TicTacToe.Player2;
        // }
        
        // private void SetCurrentPlayer()
        // {
        //     _currentPlayer = (Round % 2 == 0) ? Player2 : Player1;
        // }
        
        public bool IsPlayerOneTurn()
        {
            return (TicTacToe.Round % 2 == 1);
        }

        
        // public void PlacePlayer1Token(int x, int y)
        // {
        //     TicTacToe.GameBoard.PlaceToken(x, y, Token.X);
        // }
        //
        // public void PlacePlayer2Token(int x, int y)
        // {
        //     TicTacToe.GameBoard.PlaceToken(x, y, Token.O);
        // }
    }
}