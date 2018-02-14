namespace TicTacToe.Core
{
    public class Board
    {
        private readonly char[,] cells = new char[3,3];

        public void SetCell(int x, int y, char character)
        {
            cells[x, y] = character;
        }

        public char GetCell(int x, int y)
        {
            return cells[x, y];
        }
    }
}