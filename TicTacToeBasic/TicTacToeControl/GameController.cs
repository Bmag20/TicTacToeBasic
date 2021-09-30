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
            while (!TicTacToe.IsEnded())
            {
                ConductTurn();
                TicTacToe.CheckForWinner();
                TicTacToe.SwitchCurrentPlayer();
            }
            if (TicTacToe.GameBoard.IsFull())
                _outputWriter.BoardIsFull();
            else
                _outputWriter.AnnounceWinner(TicTacToe.Winner.PlayerName);
        }

        // too lengthy
        private void ConductTurn()
        {
            var inputAccepted = false;
            while (!inputAccepted)
            {
                _outputWriter.InputPrompt(TicTacToe.CurrentPlayer); // rename
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
                else if (InputValidator.IsQuit(playerInput))
                {
                    TicTacToe.CurrentPlayerQuit();
                    _outputWriter.PlayerQuit();
                    inputAccepted = true;
                }
                else
                    _outputWriter.ErrorPrompt("Invalid Input!!");
            }
            _outputWriter.PrintBoard(TicTacToe.GameBoard);
        }
        
    }
}