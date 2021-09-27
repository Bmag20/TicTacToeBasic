using TicTacToeBasic.Entities;

namespace TicTacToeBasic
{
    public interface IOutputWriter
    {
        void PrintWelcomeMessage(); 
        void PrintBoard(Board board);

    }
}