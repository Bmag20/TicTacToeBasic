using System;

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
            for (var i = 0; i < board.Size; i++)
            {
                for (var j = 0; j < board.Size; j++)
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