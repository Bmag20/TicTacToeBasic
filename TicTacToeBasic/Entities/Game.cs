using System.Linq;
using TicTacToeBasic.TicTacToeControl;

namespace TicTacToeBasic.Entities
{
    public class Game
    {
        public Board GameBoard { get; }
        public Player Player1 { get; }
        public Player Player2 { get;  }
        
       // public bool IsEnded { get; set; }
        public Player CurrentPlayer { get; private set; }
        public Player Winner { get; private set; }

        public Game(Board board, Player player1, Player player2)
        {
            GameBoard = board;
            Player1 = player1;
            Player2 = player2;
            CurrentPlayer = Player1; // can be set based on number of tokens on board
        }

        public void PlaceCurrentPlayerTokenOnBoard(string playerInput)
        {
            var coOrdinates = ParseInputIntoCoOrdinates(playerInput); 
            GameBoard.PlaceToken(coOrdinates[0], coOrdinates[1], CurrentPlayer.PlayerToken);
        }
        
        // part of gamecontroller?
        private static int[] ParseInputIntoCoOrdinates(string location)
        {
            return location.Split(',').Select(int.Parse).ToArray();
        }

        public void SwitchCurrentPlayer()
        {
            CurrentPlayer = (CurrentPlayer == Player1) ? Player2 : Player1;
        }

        public bool IsEnded() => GameBoard.IsFull() || Winner is not null;

        public void CheckForWinner()
        {
            if (WinDecider.IsWinner(GameBoard, CurrentPlayer))
                Winner = CurrentPlayer;
        }

        public void CurrentPlayerQuit()
        {
            SwitchCurrentPlayer();
            Winner = CurrentPlayer;
        }
    }
}