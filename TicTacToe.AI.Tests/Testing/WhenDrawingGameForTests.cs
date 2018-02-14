using ApprovalTests;
using NUnit.Framework;

namespace TicTacToe.AI.Tests.Testing
{
    [TestFixture]
    public class WhenDrawingGameForTests : GameTest
    {
        [Test]
        public void Draws_Nice_Ascii_Representation()
        {
            Board.SetCell(1, 1, 'X');
            Board.SetCell(2, 2, 'O');

            Approvals.Verify(Board.Ascii());
        }
    }
}
