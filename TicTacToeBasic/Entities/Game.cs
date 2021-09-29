namespace TicTacToeBasic.Entities
{
    public class Game
    {
        public Board GameBoard { get; }
        public Player Player1 { get; }
        public Player Player2 { get;  }
        public bool IsEnded { get; set; }
        // current player
        
        // Remove dependencies
        public Game()
        {
            GameBoard = new Board();
            Player1 = new Player(Token.X, "Player 1");
            Player2 = new Player(Token.O, "Player 2");
            IsEnded = false;
        }
        
        // place token
    }
}