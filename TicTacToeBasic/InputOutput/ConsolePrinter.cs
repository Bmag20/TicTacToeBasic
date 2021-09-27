using System;
using TicTacToeBasic.Entities;

namespace TicTacToeBasic
{
    public class ConsolePrinter : IOutputWriter
    {
        public void PrintWelcomeMessage()
        {
            Console.WriteLine("Welcome to Tic Tac Toe!");
        }

        public void PrintBoard(Board board)
        {
            for (var i = 0; i < board.GetSize(); i++)
            {
                for (var j = 0; j < board.GetSize(); j++)
                {
                    if (board.GetCells()[i, j] == Token.None)
                        Console.Write(".");
                    else
                        Console.Write(board.GetCells()[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}