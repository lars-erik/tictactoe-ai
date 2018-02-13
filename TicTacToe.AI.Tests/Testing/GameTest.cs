using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TicTacToe.AI.Tests.Core;

namespace TicTacToe.AI.Tests.Testing
{
    public class GameTest
    {
        protected Board Board;
        protected Player PlayerA;
        protected Player PlayerB;

        [SetUp]
        public void Setup()
        {
            Board = new Board();

            PlayerA = new Player(Board, 'X');
            PlayerB = new Player(Board, 'O');
        }

        [TearDown]
        public void TearDown()
        {
            Board.Dump();
            Randomizer.RandomSeed();
        }

        protected void TakeTurns(int turns)
        {
            for (var i = 0; i < turns; i++)
            {
                PlayerA.TakeTurn();
                PlayerB.TakeTurn();
            }
        }

        protected void VerifyCell(int expectedX, int expectedY, char expected)
        {
            Assert.That(Board.GetCell(expectedX, expectedY), Is.EqualTo(expected));
        }
    }
}
