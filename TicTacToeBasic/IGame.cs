namespace TicTacToeBasic
{
    public interface IGame
    {
        Board GameBoard { get; }
        Player Player1 { get; } 
        Player Player2 { get; }
    }
}