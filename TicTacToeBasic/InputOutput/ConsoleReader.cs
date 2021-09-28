using System;

namespace TicTacToeBasic.InputOutput
{
    public class ConsoleReader : IInputReader
    {
        public string ReadPlayerInput()
        {
            return Console.ReadLine();
        }
    }
}