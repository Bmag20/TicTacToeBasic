using System.Linq;

namespace TicTacToeBasic.Entities
{
    public class Game
    {
        public Board GameBoard { get; }
        public Player Player1 { get; }
        public Player Player2 { get;  }
        public bool IsEnded { get; set; }
        // current player
        public Player CurrentPlayer { get; private set; }

        // Remove dependencies
        public Game(Board board, Player player1, Player player2)
        {
            GameBoard = board;
            Player1 = player1;
            Player2 = player2;
            IsEnded = false;
            CurrentPlayer = Player1;
        }

        public void PlaceCurrentPlayerTokenOnBoard(string playerInput)
        {
            var coOrdinates = ParseInputIntoCoOrdinates(playerInput); 
            GameBoard.PlaceToken(coOrdinates[0], coOrdinates[1], CurrentPlayer.PlayerToken);
        }
        
        private static int[] ParseInputIntoCoOrdinates(string location)
        {
            return location.Split(',').Select(int.Parse).ToArray();
        }

        public void SwitchCurrentPlayer()
        {
            CurrentPlayer = (CurrentPlayer == Player1) ? Player2 : Player1;
        }
        
    }
}