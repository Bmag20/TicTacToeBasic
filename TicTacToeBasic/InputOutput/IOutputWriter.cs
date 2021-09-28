using TicTacToeBasic.Entities;

namespace TicTacToeBasic.InputOutput
{
    public interface IOutputWriter
    {
        void WelcomeMessage();
        void PrintBoard(Board board);
        void MoveAccepted();
        void AnnounceWinner();
        void ErrorPrompt(string errorMessage);
        void BoardIsFull();
        void InputPrompt(Player player);
        void PlayerQuit(string playerName);
    }
}