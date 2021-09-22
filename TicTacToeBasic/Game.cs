namespace TicTacToeBasic
{
    public class Game
    {
        public GameState State { get; set; }
        private IOutputWriter _outputWriter;
        private IInputReader _inputReader;
        public Board GameBoard { get; set; }
        private const int BoardSize = 3;

        private int round;

        public Game(IOutputWriter outputWriter, IInputReader inputReader)
        {
            State = new GameState();
            _outputWriter = outputWriter;
            _inputReader = inputReader;
            GameBoard = new Board(BoardSize);
            round = 1;
        }

        public void Start()
        {
            _outputWriter.PrintWelcomeMessage();
            _outputWriter.PrintBoard(GameBoard);

            //var input = _inputReader.ReadPlayerInput();
           // GameBoard.PlaceToken(input[0], input[2], Token.X);
        }
        
        // private void SetCurrentPlayer()
        // {
        //     _currentPlayer = (Round % 2 == 0) ? Player2 : Player1;
        // }
        
        public bool IsPlayerOneTurn()
        {
            return (State.Round % 2 == 1);
        }

        
        // public void PlacePlayer1Token(int x, int y)
        // {
        //     TicTacToe.GameBoard.PlaceToken(x, y, Token.X);
        // }
        //
        // public void PlacePlayer2Token(int x, int y)
        // {
        //     TicTacToe.GameBoard.PlaceToken(x, y, Token.O);
        // }
    }
}