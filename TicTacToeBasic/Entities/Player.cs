namespace TicTacToeBasic.Entities
{
    public class Player
    {
        public Player(Token token, string playerName)
        {
            PlayerToken = token;
            PlayerName = playerName;
        }

        public Token PlayerToken { get; }
        public string PlayerName { get; }
    }
}