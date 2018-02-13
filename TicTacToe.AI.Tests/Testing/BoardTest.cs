using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TicTacToe.AI.Tests.Core;

namespace TicTacToe.AI.Tests.Testing
{
    public class BoardTest
    {
        protected Board Board;

        [SetUp]
        public void Setup()
        {
            Board = new Board();
        }

        [TearDown]
        public void TearDown()
        {
            Board.Dump();
            Board = null;

            Randomizer.RandomSeed();
        }
    }
}
