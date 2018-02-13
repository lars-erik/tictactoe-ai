namespace TicTacToe.AI.Tests.Core
{
    public class Player
    {
        private const char Free = '\0';
        private readonly Board board;
        private readonly char playerChar;

        public Player(Board board, char playerChar)
        {
            this.board = board;
            this.playerChar = playerChar;
        }

        public void TakeTurn()
        {
            var center = board.GetCell(1, 1);
            if (center == Free)
            {
                board.SetCell(1, 1, playerChar);
                return;
            }

            var xCorner = Randomizer.NextEdge();
            var yCorner = Randomizer.NextEdge();
            for (var corner = 0; corner < 4; corner++)
            {
                var cornerChar = board.GetCell(xCorner, yCorner);
                if (cornerChar == Free)
                {
                    board.SetCell(xCorner, yCorner, playerChar);
                    return;
                }
            }
        }
    }
}