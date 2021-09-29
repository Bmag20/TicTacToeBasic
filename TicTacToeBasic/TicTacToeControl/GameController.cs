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
        private const int MaximumTokensOnBoard = 9;
        
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
                if (WinDecider.IsWinner(TicTacToe.GameBoard, TicTacToe.CurrentPlayer))
                {
                    _outputWriter.AnnounceWinner();
                    TicTacToe.IsEnded = true;
                }
                if (NumberOfTokensOnBoard() >= MaximumTokensOnBoard)
                {
                    _outputWriter.BoardIsFull();
                    TicTacToe.IsEnded = true;
                }
                _outputWriter.PrintBoard(TicTacToe.GameBoard);
                TicTacToe.SwitchCurrentPlayer();

            }
        }

        private void ConductTurn()
        {
            var inputAccepted = false;
            while (!inputAccepted)
            {
                _outputWriter.InputPrompt(TicTacToe.CurrentPlayer);
                var playerInput = _inputReader.ReadPlayerInput();

                if (InputValidator.IsValidInputFormat(playerInput))
                {
                    try
                    {
                        TicTacToe.PlaceCurrentPlayerTokenOnBoard(playerInput);
                        _outputWriter.MoveAccepted();
                        inputAccepted = true;
                    }
                    catch (InvalidDataException e)
                    {
                        _outputWriter.ErrorPrompt(e.Message);
                    }
                }
                else
                    _outputWriter.ErrorPrompt("Invalid Input!!");
                if (InputValidator.IsQuit(playerInput))
                {
                    _outputWriter.PlayerQuit(TicTacToe.CurrentPlayer.PlayerName);
                    TicTacToe.IsEnded = true;
                    inputAccepted = true;
                }
            }
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