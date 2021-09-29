using System.Collections.Generic;
using System.Linq;
using TicTacToeBasic.Entities;

namespace TicTacToeBasic.TicTacToeControl
{
    public static class WinDecider
    {
        public static bool IsWinner(Board board, Player player)
        {
            return IsHorizontalWin(board, player.PlayerToken)
                   || IsVerticalWin(board, player.PlayerToken)
                   || IsDiagonalWin(board, player.PlayerToken);
        }

        private static bool IsHorizontalWin(Board board, Token token)
        {
            for (int i = 1; i <= board.GetSize(); i++)
            {
                if (AreAllElementsSameAsToken(board.GetColumn(i), token))
                    return true;
            }

            return false;
        }

        private static bool IsVerticalWin(Board board, Token token)
        {
            for (int i = 1; i <= board.GetSize(); i++)
            {
                if (AreAllElementsSameAsToken(board.GetRow(i), token))
                    return true;
            }

            return false;
        }

        private static bool IsDiagonalWin(Board board, Token token)
        {
            return AreAllElementsSameAsToken(board.GetDiagonalLeftToRight(), token)
                   || AreAllElementsSameAsToken(board.GetDiagonalRightToLeft(), token);
        }

        private static bool AreAllElementsSameAsToken(IEnumerable<Token> arrayToCheck, Token token)
        {
            return arrayToCheck.All(t => t == token);
        }
    }
}