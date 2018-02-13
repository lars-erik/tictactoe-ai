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
    public class First_Player : BoardTest
    {
        [Test]
        [TestCase('X')]
        [TestCase('O')]
        public void Always_Chooses_Center(char playerChar)
        {
            var player = new Player(Board, playerChar);
            player.TakeTurn();
            Assert.That(Board.GetCell(1, 1), Is.EqualTo(playerChar));
        }
    }
}
