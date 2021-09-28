using System;
using TicTacToeBasic.Entities;

namespace TicTacToeBasic.InputOutput
{
    public class ConsolePrinter : IOutputWriter
    {
        public void WelcomeMessage() => Console.WriteLine("Welcome to Tic Tac Toe!");

        public void PrintBoard(Board board)
        {
            Console.WriteLine("Here's the current board:");
            for (var i = 0; i < board.GetSize(); i++)
            {
                for (var j = 0; j < board.GetSize(); j++)
                {
                    if (board.GetCells()[i, j] == Token.None)
                        Console.Write(". ");
                    else
                        Console.Write($"{board.GetCells()[i, j]} ");
                }

                Console.WriteLine();
            }
        }

        public void MoveAccepted() => Console.Write("Move accepted, ");
        public void AnnounceWinner() => Console.WriteLine("well done you've won the game!");
        public void ErrorPrompt(string errorMessage) => Console.WriteLine($"{errorMessage} Try again...");
        public void BoardIsFull() => Console.WriteLine("All fields are taken on the board! It's a draw!!");

        public void InputPrompt(Player player)
        {
            Console.Write($"{player.PlayerName} enter a coord x,y to place your {player.PlayerToken} " +
                          $"or enter 'q' to give up: ");
        }

        public void PlayerQuit(string playerName) => Console.WriteLine($"You quit the game! {playerName} lost!");
    }
}