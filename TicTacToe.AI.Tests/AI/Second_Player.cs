using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TicTacToe.AI.Tests.Core;
using TicTacToe.AI.Tests.Testing;

namespace TicTacToe.AI.Tests.AI
{
    [TestFixture]
    public class Second_Player : BoardTest
    {
        [Test]
        [TestCase(0, 2, 2)]
        [TestCase(1, 0, 0)]
        [TestCase(2, 2, 0)]
        [TestCase(3, 0, 2)]
        public void Always_Chooses_Corner(int seed, int expectedX, int expectedY)
        {
            Randomizer.Seed(seed);

            var playerA = new Player(Board, 'X');
            var playerB = new Player(Board, 'O');

            playerA.TakeTurn();
            playerB.TakeTurn();

            Assert.That(Board.GetCell(expectedX, expectedY), Is.EqualTo('O'));
        }
    }
}
