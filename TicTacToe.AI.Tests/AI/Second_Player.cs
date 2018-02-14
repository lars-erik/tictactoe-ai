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
        [TestCase(1, 2, 2)]
        [TestCase(2, 0, 2)]
        [TestCase(3, 2, 0)]
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
        [TestCase(1, 0, 2)]
        [TestCase(2, 2, 2)]
        [TestCase(3, 1, 0)]
        [TestCase(4, 2, 1)]
        public void Should_Always_Fill_Gap_On_Second_Move(int seed, int expectedX, int expectedY)
        {
            Randomizer.Seed(seed);

            TakeTurns(1);
            PlayerA.TakeTurn();
            Board.Dump();
            PlayerB.TakeTurn();

            VerifyCell(expectedX, expectedY, 'O');
            using (ApprovalResults.ForScenario(seed))
            {
                Approvals.Verify(Board.Ascii());
            }
        }


        [Test]
        [TestCase(0, 2, 0)]
        [TestCase(1, 0, 2)]
        [TestCase(2, 2, 2)]
        public void Always_Fills_Gap_On_Third_Move(int seed, int expectedX, int expectedY)
        {
            Randomizer.Seed(seed);

            TakeTurns(2);
            PlayerA.TakeTurn();
            Board.Dump();

            PlayerB.TakeTurn();

            VerifyCell(expectedX, expectedY, 'O');
            using (ApprovalResults.ForScenario(seed))
            {
                Approvals.Verify(Board.Ascii());
            }
        }

    }
}
