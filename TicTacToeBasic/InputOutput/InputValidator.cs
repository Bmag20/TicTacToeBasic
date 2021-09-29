using System.Text.RegularExpressions;

namespace TicTacToeBasic.InputOutput
{
    public static class InputValidator
    {

        public static bool IsValidInputFormat(string playerInput)
        {
            return Regex.IsMatch(playerInput, "^\\d,\\d$");
        }

        public static bool IsQuit(string playerInput)
        {
            return Regex.IsMatch(playerInput.ToLower(), "^q(uit)?$");
        }

    }
}