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
    public class Second_Player : GameTest
    {
        [Test]
        [TestCase(0, 2, 2)]
        [TestCase(1, 0, 0)]
        [TestCase(2, 2, 0)]
        [TestCase(3, 0, 2)]
        public void Always_Chooses_Corner(int seed, int expectedX, int expectedY)
        {
            Randomizer.Seed(seed);

            TakeTurns(1);

            VerifyCell(expectedX, expectedY, 'O');
            using (ApprovalResults.ForScenario(seed))
            {
                Approvals.Verify(Board.Ascii());
            }
        }

        [Test]
        [TestCase(0, 2, 0)]
        public void Always_Chooses_Adjacent_Corner_On_Second_Move(int seed, int expectedX, int expectedY)
        {
            Randomizer.Seed(seed);

            TakeTurns(1);
            TakeTurns(1);

            VerifyCell(expectedX, expectedY, 'O');
        }
    }
}
