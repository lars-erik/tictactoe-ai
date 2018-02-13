using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApprovalTests;
using ApprovalTests.Namers;
using NUnit.Framework;
using TicTacToe.AI.Tests.Core;
using TicTacToe.AI.Tests.Testing;

namespace TicTacToe.AI.Tests.AI
{
    [TestFixture]
    public class First_Player : GameTest
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

        [Test]
        [TestCase(0, 0, 2)]
        [TestCase(1, 0, 2)]
        [TestCase(2, 0, 0)]
        [TestCase(3, 2, 2)]
        public void Always_Chooses_Adjacent_Corner_To_Second_Player_On_Second_Move(int seed, int expectedX, int expectedY)
        {
            Randomizer.Seed(seed);

            TakeTurns(1);

            PlayerA.TakeTurn();

            VerifyCell(expectedX, expectedY, 'X');
            using (ApprovalResults.ForScenario(seed))
            {
                Approvals.Verify(Board.Ascii());
            }
        }
    }
}
