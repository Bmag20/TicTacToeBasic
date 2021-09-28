using System;
using TicTacToeBasic.InputOutput;

namespace TicTacToeBasic
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            IInputReader inputHandler = new ConsoleReader();
            IOutputWriter outputHandler = new ConsolePrinter();
            Game game = new Game();
            GameController gameController = new GameController(game, outputHandler, inputHandler);
            gameController.StartGame();
        }
    }
}