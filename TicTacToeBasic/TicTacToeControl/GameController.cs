using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using TicTacToeBasic.Entities;
using TicTacToeBasic.InputOutput;

namespace TicTacToeBasic
{
    public class GameController
    {
        public Game TicTacToe { get; set; }
        private readonly IOutputWriter _outputWriter;
        private readonly IInputReader _inputReader;
        public Player CurrentPlayer { get; private set; }



        public GameController(Game game, IOutputWriter outputWriter, IInputReader inputReader)
        {
            TicTacToe = game;
            _outputWriter = outputWriter;
            _inputReader = inputReader;
        }

        public void StartGame()
        {
            _outputWriter.WelcomeMessage();
            _outputWriter.PrintBoard(TicTacToe.GameBoard);
            while (!TicTacToe.IsEnded)
            {
                CurrentPlayer = IsPlayerOneTurn() ? TicTacToe.Player1 : TicTacToe.Player2;
                ConductTurn();
                if (WinDecider.IsWinner(TicTacToe.GameBoard, CurrentPlayer))
                {
                    _outputWriter.AnnounceWinner();
                    _outputWriter.PrintBoard(TicTacToe.GameBoard);
                    TicTacToe.IsEnded = true;
                }
                if (TicTacToe.Round >= 9)
                {
                    _outputWriter.BoardIsFull();
                    _outputWriter.PrintBoard(TicTacToe.GameBoard);
                    TicTacToe.IsEnded = true;
                }
            }
        }

        // private void ConductTurn()
        // {
        //     var inputAccepted = false;
        //     while (!inputAccepted)
        //     {
        //         _outputWriter.InputPrompt(CurrentPlayer);
        //         var playerInput = _inputReader.ReadPlayerInput();
        //         if (InputValidator.IsQuit(playerInput))
        //         {
        //             inputAccepted = true;
        //             TicTacToe.InProgress = false;
        //             _outputWriter.PlayerQuit(CurrentPlayer.PlayerName);
        //         }
        //         if (!InputValidator.IsValidInput(playerInput)) continue;
        //         try
        //         {
        //             var coOrdinates = ParseInputIntoCoOrdinates(playerInput);
        //             TicTacToe.GameBoard.PlaceToken(coOrdinates[0], coOrdinates[1], Token.X);
        //             TicTacToe.Round++;
        //             inputAccepted = true;
        //         }
        //         catch (InvalidDataException e)
        //         {
        //             _outputWriter.ErrorPrompt(e.Message);
        //         }
        //     }
        // }
        
        private void ConductTurn()
        {
            while (true)
            {
                _outputWriter.InputPrompt(CurrentPlayer);
                var playerInput = _inputReader.ReadPlayerInput();
                if (InputValidator.IsQuit(playerInput))
                {
                    TicTacToe.IsEnded = true;
                    _outputWriter.PlayerQuit(CurrentPlayer.PlayerName);
                    break;
                }
                if (!InputValidator.IsValidInput(playerInput)) continue;
                try
                {
                    var coOrdinates = ParseInputIntoCoOrdinates(playerInput);
                    TicTacToe.GameBoard.PlaceToken(coOrdinates[0], coOrdinates[1], Token.X);
                    TicTacToe.Round++;
                    break;
                }
                catch (InvalidDataException e)
                {
                    _outputWriter.ErrorPrompt(e.Message);
                }
            }
        }
        private static int[] ParseInputIntoCoOrdinates(string location)
        {
            return location.Split(',').Select(int.Parse).ToArray();
        }
        // private void SetCurrentPlayer()
        // {
        //     _currentPlayer = (Round % 2 == 0) ? Player2 : Player1;
        // }
        
        public bool IsPlayerOneTurn()
        {
            return (TicTacToe.Round % 2 == 1);
        }
        
    }
}