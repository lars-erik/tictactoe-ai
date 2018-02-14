using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace TicTacToe.AI.Tests.Core
{
    public class Player
    {
        private const char Free = '\0';
        private readonly Board board;
        private readonly char playerChar;
        private char opponentChar;

        public Player(Board board, char playerChar)
        {
            this.board = board;
            this.playerChar = playerChar;
            this.opponentChar = playerChar == 'X' ? 'O' : 'X';
        }

        public void TakeTurn()
        {
            var scores = PointScores();
            if (FillGap(scores)) return;
            if (TakeCenter()) return;
            if (TakeUsefulSpot(scores)) return;
        }

        private bool FillGap(Dictionary<Point, int> scores)
        {
            var gap = scores.FirstOrDefault(s => s.Value == -2);
            if (gap.Value == -2)
            {
                TakeCell(gap.Key.X, gap.Key.Y);
                return true;
            }
            return false;
        }

        private bool TakeUsefulSpot(Dictionary<Point, int> scorePoints)
        {
            var bestPair = scorePoints.OrderByDescending(s => s.Value).FirstOrDefault();
            if (scorePoints.Count > 0)
            {
                TakeCell(bestPair.Key.X, bestPair.Key.Y);
                return true;
            }

            return false;
        }

        private Dictionary<Point, int> PointScores()
        {
            Dictionary<Point, int> scores = new Dictionary<Point, int>();

            var startX = Randomizer.Next();
            var startY = Randomizer.Next();
            for (var ix = 0; ix < 3; ix++)
            {
                var x = (startX + ix) % 3;
                for (var iy = 0; iy < 3; iy++)
                {
                    var y = (startY + iy) % 3;

                    var point = new Point(x, y);

                    var value = board.GetCell(x, y);
                    if (value != Free)
                    {
                        continue;
                    }

                    var score = Calculate(point, x, y);

                    scores.Add(point, score);
                }
            }
            return scores;
        }

        private int Calculate(Point point, int x, int y)
        {
            int score = 0;

            var horizontal = EvaluateHorizontal(point);
            if (horizontal == -2) return horizontal;
            score += horizontal;

            var vertical = EvaluateVertical(point);
            if (vertical == -2) return vertical;
            score += vertical;

            if (x != 1 && y != 1)
            {
                var diagonal = EvaluateDiagonal(point);
                if (diagonal == -2) return diagonal;
                score += diagonal;
            }
            return score;
        }

        private int EvaluateHorizontal(Point point)
        {
            var availableOrOwn = 0;
            var opponent = 0;
            for (var x = 0; x < 3; x++)
            {
                var cell = board.GetCell(x, point.Y);
                if (Own(cell))
                {
                    availableOrOwn+=2;
                }
                else if (Opponent(cell))
                {
                    opponent--;
                }
                else
                {
                    availableOrOwn++;
                }
            }
            if (opponent == -2)
            {
                return opponent;
            }
            return availableOrOwn + opponent;
        }

        private int EvaluateVertical(Point point)
        {
            var availableOrOwn = 0;
            var opponent = 0;
            for (var y = 0; y < 3; y++)
            {
                var cell = board.GetCell(point.X, y);
                if (Own(cell))
                {
                    availableOrOwn += 2;
                }
                else if (Opponent(cell))
                {
                    opponent--;
                }
                else
                {
                    availableOrOwn++;
                }
            }
            if (opponent == -2)
            {
                return opponent;
            }
            return availableOrOwn + opponent;
        }

        private int EvaluateDiagonal(Point point)
        {
            // TODO: If this would ever become GO...
            var availableOrOwn = 0;
            var opponent = 0;

            var cell = board.GetCell(point.X, point.Y);
            if (Own(cell))
            {
                availableOrOwn += 2;
            }
            else if (Opponent(cell))
            {
                opponent--;
            }
            else
            {
                availableOrOwn++;
            }

            var center = board.GetCell(1, 1);
            if (Own(center))
            {
                availableOrOwn+=2;
            }
            else if (Opponent(center))
            {
                opponent--;
            }
            else
            {
                availableOrOwn++;
            }

            var oppositeX = point.X == 0 ? 2 : 0;
            var oppositeY = point.Y == 0 ? 2 : 0;
            var opposite = board.GetCell(oppositeX, oppositeY);
            if (Own(opposite))
            {
                availableOrOwn+=2;
            }
            else if (Opponent(opposite))
            {
                opponent--;
            }
            else
            {
                availableOrOwn++;
            }

            if (opponent == -2)
            {
                return opponent;
            }
            return availableOrOwn + opponent + (opponent < 0 ? 0 : 1);
        }

        private bool Opponent(char cell)
        {
            return cell == opponentChar;
        }

        private bool Own(char cell)
        {
            return cell == playerChar;
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

        private void TakeCell(int x, int y)
        {
            board.SetCell(x, y, playerChar);
        }
    }

    public struct Point
    {
        public int X { get; }
        public int Y { get; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"{{{X},{Y}}}";
        }
    }
}