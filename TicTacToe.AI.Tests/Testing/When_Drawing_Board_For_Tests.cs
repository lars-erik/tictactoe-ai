using ApprovalTests;
using NUnit.Framework;
using TicTacToe.AI.Tests.Core;

namespace TicTacToe.AI.Tests.Testing
{
    [TestFixture]
    public class When_Drawing_Board_For_Tests : BoardTest
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
