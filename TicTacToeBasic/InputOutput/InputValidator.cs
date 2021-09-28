using System.Text.RegularExpressions;

namespace TicTacToeBasic.InputOutput
{
    public static class InputValidator
    {

        public static bool IsValidInput(string playerInput)
        {
            return Regex.IsMatch(playerInput, "^[1-3],[1-3]$");
        }

        public static bool IsQuit(string playerInput)
        {
            return Regex.IsMatch(playerInput.ToLower(), "^q(uit)?$");
        }

    }
}