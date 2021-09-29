namespace TicTacToeBasic.Entities
{
    public class Game
    {
        public Board GameBoard { get; set; }
        public Player Player1 { get; }
        public Player Player2 { get;  }
        public bool IsEnded { get; set; }
        
        public Game()
        {
            GameBoard = new Board();
            Player1 = new Player(Token.X, "Player 1");
            Player2 = new Player(Token.O, "Player 2");
            IsEnded = false;
        }
    }
}