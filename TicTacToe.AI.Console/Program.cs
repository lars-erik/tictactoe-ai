using System;
using System.Text;
using System.Threading;
using TicTacToe.AI;
using TicTacToe.Core;

namespace TicTacToe
{
    class Program
    {
        private static int TurnTime = 1050;

        static void Main(string[] args)
        {
            int turn = -1;
            Board board = null;
            Player playerA = null;
            Player playerB = null;
            while (true)
            {
                if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Q)
                {
                    return;
                }

                if (turn == -1 || turn == 5)
                {
                    turn = 0;
                    board = new Board();
                    playerA = new Player(board, 'X');
                    playerB = new Player(board, 'O');
                    Dump(board);
                    Thread.Sleep(TurnTime);

                }

                playerA.TakeTurn();
                Dump(board);
                Thread.Sleep(TurnTime);

                playerB.TakeTurn();
                Dump(board);
                Thread.Sleep(TurnTime);

                turn++;
                TurnTime = Math.Max(TurnTime - 50, 10);

            }
        }

        public static void Dump(Board board)
        {
            Console.SetCursorPosition(0, 0);
            board.Dump();
            Console.WriteLine("Press Q to quit");
        }
    }
}
