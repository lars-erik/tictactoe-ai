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
        [TestCase(1, 2, 0)]
        [TestCase(2, 0, 0)]
        [TestCase(3, 2, 2)]
        [TestCase(4, 0, 2)]
        public void Always_Chooses_Spot_With_Least_Opponents_On_Second_Move(int seed, int expectedX, int expectedY)
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

        [Test]
        [TestCase(0, 2, 1)]
        [TestCase(1, 1, 2)]
        [TestCase(2, 1, 2)]
        public void Always_Fills_Gap_On_Third_Move(int seed, int expectedX, int expectedY)
        {
            Randomizer.Seed(seed);

            TakeTurns(2);

            Board.Dump();

            PlayerA.TakeTurn();

            VerifyCell(expectedX, expectedY, 'X');
            using (ApprovalResults.ForScenario(seed))
            {
                Approvals.Verify(Board.Ascii());
            }
        }

        [Test]
        [TestCase(0, 1, 2)]
        [TestCase(1, 2, 1)]
        [TestCase(2, 0, 1)]
        public void Should_Attempt_Open_Line_On_Fourth_Move(int seed, int expectedX, int expectedY)
        {
            Randomizer.Seed(seed);

            TakeTurns(3);
            Board.Dump();
            PlayerA.TakeTurn();

            VerifyCell(expectedX, expectedY, 'X');
            using (ApprovalResults.ForScenario(seed))
            {
                Approvals.Verify(Board.Ascii());
            }
        }

        [Test]
        public void Should_Have_To_Fill_In_Final_Slot_On_Fifth()
        {
            Randomizer.Seed(0);
            TakeTurns(4);
            PlayerA.TakeTurn();
            Approvals.Verify(Board.Ascii());
        }
    }
}
