using System;
using System.Text;
using TicTacToe.AI.Tests.Core;

namespace TicTacToe.AI.Tests.Testing
{
    public static class BoardTestExtensions
    {
        public static void Dump(this Board board)
        {
            Console.WriteLine(Ascii(board));
        }

        public static string Ascii(this Board board)
        {
            var builder = new StringBuilder(91);
            for(var y = 0; y<3; y++)
            { 
                Separator(builder);
                Row(board, y, builder);
            }
            Separator(builder);
            return builder.ToString();
        }

        private static void Row(Board board, int y, StringBuilder builder)
        {
            for(var x = 0; x<3; x++)
            { 
                builder.Append("| ");
                var value = board.GetCell(x, y);
                if (value == '\0')
                {
                    value = ' ';
                }
                builder.Append(value);
                builder.Append(" ");
            }

            builder.AppendLine("|");
        }

        private static void Separator(StringBuilder builder)
        {
            builder.AppendLine("+---+---+---+");
        }
    }
}