using System.IO;
using System.Linq;
using TicTacToeBasic.Entities;
using TicTacToeBasic.InputOutput;

namespace TicTacToeBasic.TicTacToeControl
{
    public class GameController
    {
        private Game TicTacToe { get; }
        private readonly IOutputWriter _outputWriter;
        private readonly IInputReader _inputReader;
        public Player CurrentPlayer { get; private set; }
        
        public GameController(Game game, IOutputWriter outputWriter, IInputReader inputReader)
        {
            TicTacToe = game;
            _outputWriter = outputWriter;
            _inputReader = inputReader;
        }

        public void ConductGame()
        {
            _outputWriter.WelcomeMessage();
            _outputWriter.PrintBoard(TicTacToe.GameBoard);
            while (!TicTacToe.IsEnded)
            {
                ConductTurn();
                if (WinDecider.IsWinner(TicTacToe.GameBoard, CurrentPlayer))
                {
                    _outputWriter.AnnounceWinner();
                    TicTacToe.IsEnded = true;
                }
                if (NumberOfTokensOnBoard() == 9)
                {
                    _outputWriter.BoardIsFull();
                    TicTacToe.IsEnded = true;
                }
                _outputWriter.PrintBoard(TicTacToe.GameBoard);
            }
        }

        private void ConductTurn()
        {
            SetCurrentPlayer();
            var inputAccepted = false;
            while (!inputAccepted)
            {
                _outputWriter.InputPrompt(CurrentPlayer);
                var playerInput = _inputReader.ReadPlayerInput();
                
                if (InputValidator.IsValidInputFormat(playerInput))
                    inputAccepted = TryAndPlaceTokenOnBoard(playerInput);
                
                else
                    _outputWriter.ErrorPrompt("Invalid Input!!");
                if (InputValidator.IsQuit(playerInput))
                {
                    _outputWriter.PlayerQuit(CurrentPlayer.PlayerName);
                    TicTacToe.IsEnded = true;
                    inputAccepted = true;
                }
            }
        }

        private bool TryAndPlaceTokenOnBoard(string playerInput)
        {
            var success = true;
            try
            {
                var coOrdinates = ParseInputIntoCoOrdinates(playerInput);
                TicTacToe.GameBoard.PlaceToken(coOrdinates[0], coOrdinates[1], CurrentPlayer.PlayerToken);
                _outputWriter.MoveAccepted();
            }
            catch (InvalidDataException e)
            {
                _outputWriter.ErrorPrompt(e.Message);
                success = false;
            }
            return success;
        }
        
        private static int[] ParseInputIntoCoOrdinates(string location)
        {
            return location.Split(',').Select(int.Parse).ToArray();
        }
        
        private void SetCurrentPlayer()
        {
            CurrentPlayer = IsPlayerOneTurn() ? TicTacToe.Player1 : TicTacToe.Player2;
        }

        private bool IsPlayerOneTurn()
        {
            return (NumberOfTokensOnBoard() % 2 == 0);
        }

        private int NumberOfTokensOnBoard()
        {
            int tokensCount = 0;
            for (int i = 1; i <= TicTacToe.GameBoard.GetSize(); i++)
            {
                tokensCount += TicTacToe.GameBoard.GetRow(i).Count(token => token != Token.None);
            }
            return tokensCount;
        }
        
    }
}