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
            // TODO: Inject and handle stupid moves by either player

            if (TakeCenter()) return;
            if (TakeCornerWithFreeOpposite()) return;
            if (TakeCornerWithOwnAdjacent()) return;
            if (TakeLastCorner()) return;
        }

        // Turn one - Player One
        private bool TakeCenter()
        {
            var center = board.GetCell(1, 1);
            if (center == Free)
            {
                TakeCell(1, 1);
                return true;
            }
            return false;
        }

        // Turn one and two - Player two
        private bool TakeCornerWithFreeOrOwnAdjacent()
        {
            
        }

        // Turn two - Player one
        private bool TakeCornerWithFreeOpposite()
        {
            var x = Randomizer.NextEdge();
            var y = Randomizer.NextEdge();
            for (var corner = 0; corner < 2; corner++)
            {
                var xOpposite = x == 0 ? 2 : 0;
                var yOpposite = y == 0 ? 2 : 0;
                var cornerChar = board.GetCell(x, y);
                var oppositeChar = board.GetCell(xOpposite, yOpposite);
                if (cornerChar == Free && oppositeChar == Free)
                {
                    TakeCell(x, y);
                    return true;
                }
                var prevX = x;
                x = ((y-1) * -1)+1;
                y = prevX;
            }
            return false;
        }

        private bool TakeLastCorner()
        {
            for (var x = 0; x < 3; x += 2)
            {
                for (var y = 0; y < 3; y += 2)
                {
                    var cornerChar = board.GetCell(x, y);
                    if (cornerChar == Free)
                    {
                        TakeCell(x, y);
                        return true;
                    }
                }
            }
            return false;
        }

        private void TakeCell(int x, int y)
        {
            board.SetCell(x, y, playerChar);
        }
    }
}