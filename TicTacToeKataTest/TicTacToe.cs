namespace TicTacToeKataTest
{
    internal class TicTacToe
    {
        public TicTacToe()
        {
            Grid = new List<List<char?>>
            { 
                CreateLine(),
                CreateLine(),
                CreateLine()
            };

            Players = new List<char>() { 'X', 'O' };
        }

        private bool _secondPlayerIsPlaying;

        private static List<char?> CreateLine()
        {
            return new List<char?> { null, null, null };
        }

        public List<List<char?>> Grid { get; internal set; }
        public List<char> Players { get; internal set; }
        public bool GameOver 
        { 
            get
            {
                return IsGridTotallyFilled();
            }
        }

        private bool IsGridTotallyFilled()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (Grid[i][j] == null)
                        return false;
                }
            }
            return true;
        }

        internal void Play(int row, int column)
        {
            char symbolOfCurrentPlayer = _secondPlayerIsPlaying ? Players[1] : Players[0];
            Grid[row][column] = symbolOfCurrentPlayer;
            _secondPlayerIsPlaying = !_secondPlayerIsPlaying;
        }
    }
}