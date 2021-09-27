using TicTacToeBasic.Entities;

namespace TicTacToeBasic
{
    public class Game
    {
        public Board GameBoard { get; }
        public Player Player1 { get; }
        public Player Player2 { get;  }

        public int Round { get; set; }
        public Player Winner { get; set; }
        
        public Game()
        {
            GameBoard = new Board();
            Player1 = new Player(Token.X);
            Player2 = new Player(Token.O);
            Round = 1;
        }


        
    }
}