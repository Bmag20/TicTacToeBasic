using System;

namespace TicTacToeBasic
{
    public class ConsoleReader : IInputReader
    {
        public string ReadPlayerInput()
        {
            return Console.ReadLine();
        }
    }
}