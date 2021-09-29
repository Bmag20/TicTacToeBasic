using System;
using TicTacToeBasic.Entities;
using TicTacToeBasic.InputOutput;
using TicTacToeBasic.TicTacToeControl;

namespace TicTacToeBasic
{
    static class Program
    {
        static void Main(string[] args)
        {
            IInputReader inputHandler = new ConsoleReader();
            IOutputWriter outputHandler = new ConsolePrinter();
            var board = new Board();
            var player1 = new Player(Token.X, "Player 1");
            var player2 = new Player(Token.O, "Player 2");
            var game = new Game(board, player1, player2);
            var gameController = new GameController(game, outputHandler, inputHandler);
            gameController.ConductGame();
        }
    }
}