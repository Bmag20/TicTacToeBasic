namespace TicTacToeBasic.Entities
{
    public class Player
    {
        public Player(Token token)
        {
            PlayerToken = token;
        }

        public Token PlayerToken { get; }
    }
}